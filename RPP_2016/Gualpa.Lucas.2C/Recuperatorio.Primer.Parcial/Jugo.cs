using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperatorio.Primer.Parcial
{

   //public   enum ESaborJugo{Pasable, Asqueroso }

    public class Jugo:Producto
    {
        public enum ESaborJugo { Pasable, Asqueroso }
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.40; }
        }

        static Jugo()
        {
            Jugo.DeConsumo = true;
        }

        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor):base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }

        private string MostrarJugo()
        {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + this._marca);
            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoBarra);
            sb.AppendLine("PRECIO: " + this._precio);
            sb.AppendLine("SABOR: " + this._sabor);

            return sb.ToString();

            
        }

        public override string ToString()
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return " Bebible";
        }

    }
}
