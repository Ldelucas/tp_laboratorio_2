using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }



        public bool guardar(string datos)
        {
             bool aux = false;
             try
             {

                 using (StreamWriter sw = new StreamWriter(this._archivo, true))
                 {
                     sw.WriteLine(datos);
                     aux = true;
                 }

                 return aux;
             }
             catch(Exception)
             {
                 return aux;
             }
            
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            
            using (StreamReader file = new StreamReader(this._archivo))
            {
                while(!file.EndOfStream)
                {
                    datos.Add(file.ReadLine());
                }
            }

            return true;
        }
        
    }
}
