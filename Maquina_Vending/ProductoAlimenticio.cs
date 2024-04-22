using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class ProductoAlimenticio : Producto
    {        
        public string Informacion { get; set; }

        public ProductoAlimenticio(string nombre, int unidades, double precioUnidad, string descripcion, string informacion)
        : base(nombre, unidades, precioUnidad, descripcion)
        {
            this.Informacion = informacion;            
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: {PrecioUnidad}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Unidades disponibles: {Unidades}");
            Console.WriteLine($"Información nutricional: {Informacion}");
            
        }
    }
}
