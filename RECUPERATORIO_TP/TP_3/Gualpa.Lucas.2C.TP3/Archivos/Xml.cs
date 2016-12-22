﻿using System;
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
                bool aux = false;
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    aux = true;
                }
                return aux;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                bool aux = false;
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Xml<T>));
                    datos = (T)ser.Deserialize(reader);
                    aux = true;
                }
                return aux;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
               
            }
        }
    }
}
