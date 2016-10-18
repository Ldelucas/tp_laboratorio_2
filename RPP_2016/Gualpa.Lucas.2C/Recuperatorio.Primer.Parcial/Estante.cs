using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


using System.IO;

namespace Recuperatorio.Primer.Parcial
{
    

   public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad): this()
        {
            this._capacidad = capacidad;
        }

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAPACIDAD: "+ e._capacidad.ToString());
            

            foreach (Producto item in e.GetProductos())
            {
                
                //sb.AppendLine((string)item);
                sb.AppendLine(item.ToString());
                
            }

            return sb.ToString(); 
        }

        public static bool operator ==(Estante e, Producto prod)
        {
            bool retorno = false;

            foreach (Producto item in e.GetProductos())
            {
                if (item == prod)
                {
                    retorno = true;
                    break;
                }
                
            }
            return retorno;
        }

        public static bool operator !=(Estante e, Producto prod)
        { 
            return !(e == prod); 
        }

        public static bool operator +(Estante e, Producto prod)
        {

            if (e._productos.Count <= e._capacidad && (!(e == prod)))
            {
                e.GetProductos().Add(prod);
                return true;
            }

            return false;


        }


        

        public static Estante operator -(Estante e, Producto prod)
        {
            

            if (e == prod)
            {
                e.GetProductos().Remove(prod);
                return e;
            }

                return e;
        }


        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {

            for (int i = 0; i < e.GetProductos().Count; i++)
            {
                

                if (tipo == Producto.ETipoProducto.Galletita && (e.GetProductos()[i] is Galletita))
                {
                   e.GetProductos().RemoveAt(i);
                   i--;
                   
                  
                }
                else if (tipo == Producto.ETipoProducto.Gaseosa && (e.GetProductos()[i] is Gaseosa))
                {
                    //e.GetProductos().Remove(e.GetProductos()[i]);
                    //i--;
                    e.GetProductos().RemoveAt(i);
                    i--;
                    
                }
                else if (tipo == Producto.ETipoProducto.Jugo && (e.GetProductos()[i] is Jugo))
                {
                    e.GetProductos().RemoveAt(i);
                    i--; 
                    
                }
                else
                {
                    if (tipo == Producto.ETipoProducto.Todos)
                    {
                        
                        e.GetProductos().Clear();
                        
                    
                    }


                }
            }
            return e;
        }


        private float GetValorEstante()
        {
            return this.GetValorEstante(Producto.ETipoProducto.Todos);
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float valorTotal = 0;
           

            foreach (Producto item in GetProductos())
            {

                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        {
                            if (item is Galletita)
                                valorTotal = valorTotal + item.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Gaseosa:
                        {
                            if (item is Gaseosa)
                                valorTotal = valorTotal + item.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Harina:
                        {
                            if (item is Harina)
                                valorTotal = valorTotal + item.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Jugo:
                        {
                            if (item is Jugo)
                                valorTotal = valorTotal + item.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Todos:
                        {
                            valorTotal = valorTotal + item.Precio;
                        }
                        break;

                }
               
            //    for (int i = 0; i < e.GetProductos().Count; i++)
            //{
                //    if (tipo == Producto.ETipoProducto.Galletita)
            //    {
                //        valorTotal = valorTotal + item.Precio;
            //    }
            //    if (tipo == Producto.ETipoProducto.Gaseosa)
            //    {
                //        valorTotal = valorTotal + item.Precio;
            //    }

            //    if (tipo == Producto.ETipoProducto.Harina)
            //    {
                //        valorTotal = valorTotal + item.Precio;
            //    }

            //    if (tipo == Producto.ETipoProducto.Jugo)
            //    {
                //        valorTotal = valorTotal + item.Precio;
            //    }
            //    if (tipo == Producto.ETipoProducto.Todos)
            //    {
                //        valorTotal = valorTotal + item.Precio;
            //    }

            //}  



            }
            return valorTotal;
        }


        public float ValorEstanteTotal //retorna el tipo de producto de del metodo GetValorEstante que es privado
        {
            get { return GetValorEstante(Producto.ETipoProducto.Todos); }
            
        }





//  ********************* SERIALIZACION*************

        public static void SerializarEstante(Estante e, string nombreArchivo)
        {
            try
            {
                //XmlTextWriter InfoEstante = new XmlTextWriter(AppDomain.CurrentDomain.BaseDirectory + "InfoEstante.xml", System.Text.Encoding.UTF8);
                TextWriter InfoEstante = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + nombreArchivo);

                XmlSerializer serializador = new XmlSerializer(typeof(Estante));

                serializador.Serialize(InfoEstante, e);
                InfoEstante.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Ocurrió un error en SerializarPersona(): " + error.Message);
            }
        }

        //public static void SerializarEstante(List<Producto> productos, string nombreArchivo)
        //{
        //    try
        //    {
        //        TextWriter InfoEstante = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "InfoEstante");
        //        XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));

        //        serializador.Serialize(InfoEstante, productos);
        //        InfoEstante.Close();
        //    }
        //    catch (Exception error)
        //    {
        //        Console.WriteLine("Ocurrió un error en SerializarListaDePersonas(): " + error.Message);
        //    }
        //}






    }
}
