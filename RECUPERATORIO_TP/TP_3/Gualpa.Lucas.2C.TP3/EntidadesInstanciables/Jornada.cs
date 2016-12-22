using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesInstanciables
{

// Atributos Instructor, Clase y Alumnos que toman dicha clase.
// Se inicializará la lista de alumnos en el constructor por defecto.
// Una Jornada será igual a un Alumno si el mismo participa de la clase.
// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
//cargados.
// ToString mostrará todos los datos de la Jornada.
// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
// Leer de clase retornará los datos de la Jornada como texto.
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]

    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public List<Alumno> Alumnos
        { 
            get { return this._alumnos; } 
        }

        public Gimnasio.EClases Clase
        { 
            get { return this._clase; } 
        }

        public Instructor Instructor
        { 
            get { return this._instructor; } 
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            

            bool aux = false;
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return aux = true;
            }
            return aux;
            
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    throw new AlumnoRepetidoException();

            }
            j._alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE " + this._clase.ToString() + " ");
            sb.AppendLine("POR: " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("----------------");
            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            Texto texto = new Texto();
            return texto.Guardar(path, jornada.ToString());
        }

        public static bool Leer(Jornada jornada)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            Texto texto = new Texto();
            string salida = "";
            return texto.Leer(path, out salida);
            
        }

    }
}


