using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperatorio.Primer.Parcial
{
    public class Gaseosa:Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.42; }
        }

        static Gaseosa()
        {
            Gaseosa.DeConsumo = true;
        }

        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros):base(codigoBarra, marca, precio)
        {
            this._litros=litros;
        }

        public Gaseosa(Producto p, float litros):this((int)p,p.Precio, p.Marca, litros)
        {
            
        }

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + this._marca);
            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoBarra);
            sb.AppendLine("PRECIO: " + this._precio);
            sb.AppendLine("LITROS: " + this._litros);

            return sb.ToString();
            
        }

        public override string ToString()
        {
            return MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }





    }
}
