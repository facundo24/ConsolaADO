using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Alumno
    {
        private int idAlumno;

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private short edad;

        public Alumno(int idAlumno, string nombre, string apellido, string documento, short edad)
        {
            IdAlumno = idAlumno;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Edad = edad;
        }

        public Alumno(string nombre, string apellido, string documento, short edad)
        {
            IdAlumno = idAlumno;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Edad = edad;
        }


        public short Edad
        {
            get { return edad; }
            set { edad = value; }
        }

    }
}
