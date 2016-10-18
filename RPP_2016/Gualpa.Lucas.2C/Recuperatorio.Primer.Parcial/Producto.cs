using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperatorio.Primer.Parcial
{
   // public enum EMarcaProducto {Favorita, Pitusas, Diversión, Naranjú, Swift}

    public abstract class Producto
    {
        public  enum EMarcaProducto { Favorita, Pitusas, Diversión, Naranjú, Swift }
        public enum ETipoProducto { Harina, Gaseosa, Jugo, Galletita, Todos }

        protected int _codigoBarra;
        protected  EMarcaProducto _marca;
        protected float _precio;

        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoBarra;
           this._marca = marca;
            this._precio = precio;
        }

        public EMarcaProducto Marca
        {
            get {return this._marca;}
        }

        public float Precio
        {
             get{return this._precio;}
        }

        public abstract float CalcularCostoDeProduccion
        {
            get;
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + p._marca);
            sb.AppendLine("CODIGO DE BARRA: "+ p._codigoBarra);
            sb.AppendLine("PRECIO: " + p._precio);
            
            return sb.ToString();
        }
 
        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if  (Equals(prodUno,prodDos)== true && prodUno._codigoBarra == prodDos._codigoBarra && prodUno._marca == prodDos._marca)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }

        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            if (prodUno._marca == marca)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }

        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }

        public static implicit operator string(Producto p)
        {
            return MostrarProducto(p);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(obj, (Producto)obj)==true;
        }


        public virtual string Consumir()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Parte de una mezcla");

            return sb.ToString();
        }




    }
}
