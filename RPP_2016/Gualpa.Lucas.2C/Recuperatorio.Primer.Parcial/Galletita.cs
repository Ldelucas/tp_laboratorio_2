using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperatorio.Primer.Parcial
{
   public class Galletita : Producto
    {

        protected float _peso;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.33; }
        }
         
         static Galletita()
        {
            Galletita.DeConsumo = true;
        }

        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso):base(codigoBarra, marca, precio)
        {
            this._peso = peso;
        }

        private string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + g._marca);
            sb.AppendLine("CODIGO DE BARRAS: " + g._codigoBarra);
            sb.AppendLine("PRECIO: " + g._precio);
            sb.AppendLine("PESO: " + g._peso);

            return sb.ToString();
            //return g._marca.ToString() + g.CalcularCostoDeProduccion.ToString() + g._codigoBarra.ToString() + g._peso.ToString();
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }


    }
}
