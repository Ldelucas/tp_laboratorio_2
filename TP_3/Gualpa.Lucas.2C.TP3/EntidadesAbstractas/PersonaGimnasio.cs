using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;
        public PersonaGimnasio()//constructor con 0 parametros para serializar
        { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
                return true;
            else
                return false;
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (Equals(pg1, pg2) == true && pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
            {

                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nCARNET NUMERO: " + this._identificador);
            return base.ToString() + sb.ToString();
        }

    }
}
