using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
// Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
// ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la
    //clases que da.
// ToString hará públicos los datos del Instructor.
// Se inicializará a random sólo en un constructor.
// En el constructor de instancia se inicializará ClasesDelDia y se 
    //asignarán dos clases al azar al instructor mediante el método 
    //_randomClases. Las dos clases pueden o no ser la misma.
// Un Instructor será igual a un EClase si da esa clase.

     [Serializable]

    public sealed class Instructor: PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor()
        {
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.Append(item.ToString() + "\n");
            }

            return "CLASES DEL DIA " + "\n" + sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 3));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 3));
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }


        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }


    }
}
