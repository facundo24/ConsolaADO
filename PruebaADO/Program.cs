﻿using BusinessEntity;
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

            Alumno al = new Alumno("Pepe3", "Loco2", "1001000", 99);
            ha.InsertAlumno(al, connection);

            List<Alumno> colAlumnos = ha.GetAlumnos(connection);

            int count = ha.GetCountAlumnos(connection);

            Alumno alUpdate = new Alumno(1,"Pepe4", "Loco2", "1001000", 99);
            ha.UpdateAlumno(connection, alUpdate);

        }
    }
}
