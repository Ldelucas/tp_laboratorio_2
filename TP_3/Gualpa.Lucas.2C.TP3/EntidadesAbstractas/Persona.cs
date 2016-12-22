using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{


    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region Constructores

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value); } //llama al metodo que valida con int
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }


        public string StringToDNI//convierte de string a int
        {

            set { this.DNI = this.ValidarDni(this._nacionalidad, value); } // llama al metodo que valida con string y parsea a int
        }

        #endregion

        #region Metodos

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (dato < 1 || dato > 89999999)

                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;

                case ENacionalidad.Extranjero:

                    if (dato < 89999999 || dato > 99999999)

                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;

        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {

                if (!char.IsLetter(dato, i))
                    return "Dato invalido";

            }
            return dato;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre Completo: " + this.Apellido + " " + this.Nombre + "\n");
            sb.Append("Nacionalidad: " + this.Nacionalidad.ToString() + "\n");
           
            return sb.ToString();
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}
