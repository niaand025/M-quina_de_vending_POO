using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class ProductoElectronico : Producto
    {
        /*Los productos electrónicos incluyen el tipo de materiales utilizados, un indicador booleano para la inclusión de pilas (sí/no) 
         * y un indicador booleano para saber si el producto está precargado.*/
        public string Material { get; set; }
        public bool Pilas { get; set; }
        public bool Precargado { get; set; }

        public ProductoElectronico(string nombre, int unidades, double precioUnidad, string descripcion, string material, bool pilas, bool precargado)
        : base(nombre, unidades, precioUnidad, descripcion)
        {
            Material = material;
            Pilas = pilas;
            Precargado = precargado;
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: {PrecioUnidad}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Unidades disponibles: {Unidades}");
            Console.WriteLine($"Materiales utilizados: {Material}");
            Console.WriteLine($"Tiene pilas: {Pilas}");
            Console.WriteLine($"Precargado: {Precargado}");
        }
    }
}
