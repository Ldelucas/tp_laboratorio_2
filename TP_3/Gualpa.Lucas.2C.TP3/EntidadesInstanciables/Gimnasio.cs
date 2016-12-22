using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{

//    Atributos Alumnos (lista de inscriptos), Instructores (lista de quienes pueden dar clases) y Jornadas.
// Se accederá a una Jornada específica a través de un indexador.
// Un Gimnasio será igual a un Alumno si el mismo está inscripto en él.
// Un Gimnasio será igual a un Instructor si el mismo está dando clases en él.
// Al agregar una clase a un Gimnasio se deberá generar y agregar una nueva Jornada indicando la
//clase, un Instructor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la
//toman (todos los que coincidan en su campo ClaseQueToma).
// Se agregarán Alumnos e Instructores mediante el operador +, validando que no estén previamente
//cargados.
// La igualación entre un Gimnasio y una Clase retornará el primer instructor capaz de dar esa clase.
//Sino, lanzará la Excepción SinInstructorException. El distinto retornará el primer Instructor que no
//pueda dar la clase.
// MostrarDatos será privado y de clase. Los datos del Gimnasio se harán públicos mediante ToString.

    [XmlInclude(typeof(Jornada))]

    public class Gimnasio
    {
        public enum EClases { CrossFit, Natacion, Pilates, Yoga }

     

        private List<Alumno> _alumnos;//pase a publico para que pueda serializar
        private List<Instructor> _instructores;//pase a publico para que pueda serializar
        private List<Jornada> _jornada;//pase a publico para que pueda serializar

        public List<Alumno> Alumnos
        { get { return this._alumnos; } }//Propiedades para poder serializar las listas privadas
        public List<Instructor> Instructores
        { get { return this._instructores; } }//Propiedades para poder serializar las listas privadas
        public List<Jornada> Jornada
        { get { return this._jornada; } }//Propiedades para poder serializar las listas privadas




        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }


        public Jornada this[int i]
        { get { return this._jornada[i]; } }

     
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool aux = false;
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)//llama a sobrecarga == en personaGimnasio
                {
                    return aux = true;
                    //throw new AlumnoRepetidoException();
                }
            }
            return aux;
        }
        public static bool operator !=(Gimnasio g, Alumno a)
        { return !(g == a); }


        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool aux = false;
            foreach (Instructor item in g._instructores)
            {
                if (item == i)//llama a sobrecarga == en personaGimnasio
                    return aux = true;


            }
            return aux;

        }
        public static bool operator !=(Gimnasio g, Instructor i)
        { return !(g == i); }


        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)//Llama a sobrecarga Instructor-EClase(en instructor)
                    return item;
            }//Sino Excepción SinInstructorException

            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (!(item == clase))
                    return item;
            }
            throw new SinInstructorException();
            return null; 

        }
    

        

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
            }
            else
            {
                //throw new Excepciones.AlumnoRepetidoException();
            }

            return g;

            //if (g != a)
            //{
            //    g._alumnos.Add(a);
            //    return g;
            //}
            //throw new AlumnoRepetidoException();

           

        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);
            return g;

            
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
           

            Jornada j = new Jornada(clase, (g == clase));

            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                    j = j + item;//sobrecargas jornada + alumno

            }
            g._jornada.Add(j);//agrego la jornada
            return g;
        }

       
        #region XML

        //public static bool Guardar(Gimnasio g)
        //{
        //    Xml<Gimnasio> MiXml = new Xml<Gimnasio>();
        //    //return MiXml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimnacio.xml", g);
        //    try
        //    {
        //        String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
        //        MiXml.Guardar(ruta, g);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ArchivosException(e);
        //    }
        //}

        //public static bool Leer(Gimnasio g)
        //{
        //    Xml<Gimnasio> Xml = new Xml<Gimnasio>();
        //    try
        //    {
        //        String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
        //        Xml.Leer(ruta, out g);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ArchivosException(e);
        //    }
        //}


        public static bool Guardar(Gimnasio g)
        {
            Xml<Gimnasio> MiXml = new Xml<Gimnasio>();
            return MiXml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimnasio.xml", g);
        }

        public static Gimnasio Leer()
        {
            Gimnasio g;
            Xml<Gimnasio> MiXml = new Xml<Gimnasio>();
            MiXml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimnasio.xml", out g);
            return g;
        }


        #endregion

        #region mostrar

        private static string MostrarDatos(Gimnasio g)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in g._jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

    }
}
