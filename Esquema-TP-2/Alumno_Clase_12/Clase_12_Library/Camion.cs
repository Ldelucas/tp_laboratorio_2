using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion: Vehiculo
    {
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas//no se pueden cambiar los modificadores y no era override, agregue el set
        {
            get
            {
                return 8;
            }
            set { }
        }

        public override sealed string Mostrar()//no se pueden cambiar los modificadores
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :"+ this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
