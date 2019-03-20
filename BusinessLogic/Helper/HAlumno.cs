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
            return pa.GetAlumnos(connString);
        }
    }
}
