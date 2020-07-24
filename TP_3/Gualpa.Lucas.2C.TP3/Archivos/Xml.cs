using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        

        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Xml<T>));
                XmlTextReader reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception)
            {
                datos = default(T);
                return false;
            }
        }
    }
}
