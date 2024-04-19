using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class MaquinaVending
    {
        int slots = 12;
        public List<Producto> listaProductos;

        public MaquinaVending (List<Producto> productos)
        {
            listaProductos = productos;
        }

    }
}
