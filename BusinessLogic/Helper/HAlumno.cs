using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helper
{
    public class HAlumno
    {
        public bool InsertAlumno(Alumno alumno, string connString)
        {
            PAlumno pa = new PAlumno();
            return  pa.InsertAlumno(connString, alumno);
        }

        public List<Alumno> GetAlumnos(string connString)
        {
            PAlumno pa = new PAlumno();
            return pa.GetAlumnosDesconectado(connString);
        }

        public Alumno GetAlumnoByDocument(string connString, string documento)
        {
            PAlumno pa = new PAlumno();
            return pa.GetAlumnoByDocument(connString, documento);
        }

        public int GetCountAlumnos(string connString)
        {
            PAlumno pa = new PAlumno();
            return pa.getCountAlumnos(connString);
        }

        public int UpdateAlumno(string connString, Alumno alumnoUpdate)
        {
            PAlumno pa = new PAlumno();
            return pa.UpdateAlumno(connString, alumnoUpdate);
        }




    }
}
