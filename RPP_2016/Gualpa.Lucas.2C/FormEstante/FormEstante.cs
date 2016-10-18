using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recuperatorio.Primer.Parcial;
using TestEstante;

namespace FormEstante
{
    static class FormEstante
    {
        public static int OrdenarProductos(Producto proUno, Producto proDos)//compara entre 2 string para ordenar en forma decreciente
        {

            return String.Compare((proUno.Marca).ToString(), (proDos.Marca).ToString());

        }

        
    }
}
