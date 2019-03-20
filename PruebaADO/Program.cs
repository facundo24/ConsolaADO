using BusinessEntity;
using BusinessLogic.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            HAlumno ha = new HAlumno();

            Alumno al = new Alumno("Pepe2", "Loco2", "0001000", 99);
            ha.InsertAlumno(al, connection);

            List<Alumno> colAlumnos = ha.GetAlumnos(connection);



        }
    }
}
