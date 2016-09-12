using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase05_TP
{
    class Numero
    {
        #region ATRIBUTOS
        private double _numero; 
        #endregion
        

        #region CONSTRUCTORES
        public Numero()
        {
            this._numero = 0;

        }

        public Numero(double numero):this()
        {
            this._numero = numero;
        }

        public Numero(string numero):this()
        {
            //this._numero = (validarNumero(numero)); 
            setNumero(numero);
        }

        #endregion


        #region METODOS
        
/// <summary>
/// Metodo para validar que el numero sea de tipo double
/// </summary>
/// <param name="numeroString"></param>
/// <returns></returns>
        private static double validarNumero(string numeroString)
        {
            double num;

            bool b = double.TryParse(numeroString, out num);

            if (b)
	        {
		      //Console.WriteLine("numero double");
              return num;
	        }else
            {
                //Console.WriteLine("no es un numero de tipo double");
               // MessageBox.Show("No es un numero","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            
        }

        /// <summary>
        /// Metodo para asignarle el numero validado al atributo numero
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {

            this._numero = Numero.validarNumero(numero);
        }
        
        /// <summary>
        /// Metodo para retornar el numero
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero; 
        }

        #endregion

    }
}
