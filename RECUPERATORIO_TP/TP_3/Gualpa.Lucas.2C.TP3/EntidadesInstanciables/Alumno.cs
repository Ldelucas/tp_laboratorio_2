using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{

     [Serializable]

    public sealed class Alumno : PersonaGimnasio
    {
        /*
Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
Un Alumno será disntito a un EClase sólo si no toma esa clase
         * */
        private Gimnasio.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ESTADO DE CUENTA: " + this._estadoCuenta + "\n");
            return base.MostrarDatos() + sb.ToString() + ParticiparEnClase() + "\n";
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._clasesQueToma.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool aux = false;
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                aux = true;
            if (a._clasesQueToma != clase)
                aux = false;

            return aux;
        }
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return !(a == clase);

        }


        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }


    }
}
