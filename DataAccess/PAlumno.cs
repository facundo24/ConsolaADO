using BusinessEntity;
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
    }
}
