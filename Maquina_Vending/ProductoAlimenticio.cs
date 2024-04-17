using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class ProductoAlimenticio : Producto
    {
        /*Los productos alimenticios incluyen información nutricional para informar a los consumidores sobre 
         * el recuento de calorías, el contenido de grasa, el contenido de azúcar, etc.*/
        public string Informacion { get; set; } 
    }
}
