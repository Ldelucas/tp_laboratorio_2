using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperatorio.Primer.Parcial
{
   //public enum ETipoHarina{CuatroCeros, Integral}

    public class Harina: Producto
    {
        public  enum ETipoHarina { CuatroCeros, Integral }

        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        static Harina()
        {
            Harina.DeConsumo = true;
        }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo):base(codigoBarra, marca, precio)
        {
            this._tipo = tipo;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.60; }
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + this._marca);
            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoBarra);
            sb.AppendLine("PRECIO: " + this._precio);
            sb.AppendLine("TIPO: " + this._tipo);

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarHarina();
        }



    }
}
