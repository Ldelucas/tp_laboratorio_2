using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase05_TP
{
    class Calculadora
    {


        #region METODOS

        /// <summary>
        /// Metodo que realiza la operacion matematica y retorna el resultado
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>

        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            
            operador = validarOperador(operador);
            switch (operador)
            {
                case "+":
                    {
                        
                        resultado = numero1.getNumero() + numero2.getNumero();
                        //return resultado;
                        
                    break;
                    }

                case "-":
                    {
                        resultado = (numero1.getNumero() - numero2.getNumero());
                        //return resultado;
                        break;
                    }

                case "*":
                    {

                        resultado = numero1.getNumero() * numero2.getNumero();
                        //return resultado;
                        break;
                    }

                case "/":
                    {
                        if (numero2.getNumero() == 0)
	                    {
                            //Console.WriteLine("NO SE PUEDE DIVIDIR ENTRE CERO");
                            MessageBox.Show("NO SE PUEDE DIVIDIR ENTRE CERO","ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            resultado = 0;
                            break;
                        }
                        else
                        {
                            resultado = numero1.getNumero() / numero2.getNumero();
                            //return resultado;
                            break;
                        }

                        
                        
                    }

                
         

            }
            return resultado;
            
        }

        /// <summary>
        /// Metodo para validar que el operador sea +, -, *, ó /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>

        public static string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                //MessageBox.Show("DEBE INGRESAR UN OPERADOR +, -, *, ó /", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "+";

            return operador;


        }

        #endregion

    }
}
