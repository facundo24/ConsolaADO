﻿using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class PAlumno
    {
        public bool InsertAlumno(string connString, Alumno alumno)
        {
            try
            {
                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "INSERT INTO Alumno (nombre, apellido, edad, documento) values (@nom, @ap, @edad, @doc);";

                    cm.Parameters.Add("@nom", SqlDbType.VarChar);
                    cm.Parameters.Add("@ap", SqlDbType.VarChar);
                    cm.Parameters.Add("@edad", SqlDbType.SmallInt);
                    cm.Parameters.Add("@doc", SqlDbType.VarChar);

                    cm.Parameters["@nom"].Value = alumno.Nombre;
                    cm.Parameters["@ap"].Value = alumno.Apellido;
                    cm.Parameters["@edad"].Value = alumno.Edad;
                    cm.Parameters["@doc"].Value = alumno.Documento;

                    cm.ExecuteNonQuery();


                    cm.CommandText = "Select idAlumno, nombre, apellido, edad, documento from Alumno";
                    cm.Parameters.Clear();
                    SqlDataReader re = cm.ExecuteReader();

                    if (re.HasRows)
                    {
                        while (re.Read())
                        {
                            int idUnAlumno = re.GetInt32(0);
                            string nombreUnAlumno = re.GetString(1);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public List<Alumno> GetAlumnos(string connString)
        {
            List<Alumno> colAlumnos = new List<Alumno>();
            try
            {

                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "Select idAlumno, nombre, apellido, documento, edad from Alumno";
                    SqlDataReader re = cm.ExecuteReader();

                    if (re.HasRows)
                    {
                        while (re.Read())
                        {
                            Alumno al = new Alumno(re.GetInt32(0), re.GetString(1), re.GetString(2), re.GetString(3), re.GetInt16(4));

                            colAlumnos.Add(al);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return colAlumnos;
        }

        public List<Alumno> GetAlumnosDesconectado(string connString)
        {
            DataTable dt = null;
            SqlDataAdapter da = null;
            SqlCommandBuilder cb = null;
            DataSet ds = new DataSet();
            List<Alumno> colAlumnos = new List<Alumno>();
            try
            {

                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "Select idAlumno, nombre, apellido, documento, edad from Alumno";

                    da = new SqlDataAdapter(cm);
                    cb = new SqlCommandBuilder(da);

                    da.Fill(ds, "Alumno");
                    context.Close();


                    dt = ds.Tables["Alumno"];

        
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        dt.Rows[i].Delete();
                    }

                    /*
                    foreach (DataRow row in dt.Rows)
                    {
                        row.BeginEdit();
                        row["nombre"] = "LOCO";
                        row.EndEdit();                        
                    }*/

                    DataRow row = dt.NewRow();
                    row["nombre"] = "Pepe45";
                    row["apellido"] = "Loco45";
                    row["documento"] = "Doc";
                    dt.Rows.Add(row);

                    context.Open();
                    da.Update(ds, "Alumno");
                   
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return colAlumnos;
        }


        public Alumno GetAlumnoByDocument(string connString, string documento)
        {
            Alumno alumno = null;
            try
            {

                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "Select idAlumno, nombre, apellido, documento, edad from Alumno where documento = @doc";

                    cm.Parameters.Add("@doc", SqlDbType.VarChar).Value = documento;

                    SqlDataReader re = cm.ExecuteReader(CommandBehavior.SingleRow);
                    if (re.HasRows)
                    {
                        while (re.Read())
                        {
                            alumno = new Alumno(re.GetInt32(0), re.GetString(1), re.GetString(2), re.GetString(3), re.GetInt16(4));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return alumno;
        }

        public int getCountAlumnos(string connString)
        {
            int cantidad = 0;
            try
            {

                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "Select count(*) from Alumno";
                    cantidad = int.Parse(cm.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                return cantidad;
            }

            return cantidad;
        }

        public int UpdateAlumno(string connString, Alumno alumno)
        {
            int rowAfect = 0;
            try
            {
                SqlConnection context = new SqlConnection(connString);
                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;
                    cm.CommandText = "UPDATE Alumno SET nombre = @nom, apellido = @ap, edad = @edad, documento = @doc where idAlumno = @id";

                    cm.Parameters.Add("@id", SqlDbType.Int).Value = alumno.IdAlumno;
                    cm.Parameters.Add("@nom", SqlDbType.VarChar).Value = alumno.Nombre;
                    cm.Parameters.Add("@ap", SqlDbType.VarChar).Value = alumno.Apellido;
                    cm.Parameters.Add("@edad", SqlDbType.SmallInt).Value = alumno.Edad;
                    cm.Parameters.Add("@doc", SqlDbType.VarChar).Value = alumno.Documento;

                    rowAfect = cm.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                return rowAfect;
            }

            return rowAfect;
        }

    }
}
