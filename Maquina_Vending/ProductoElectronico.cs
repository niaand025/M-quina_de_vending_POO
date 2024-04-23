using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class ProductoElectronico : Producto
    {        
        public string Material { get; set; }
        public bool Pilas { get; set; }
        public bool Precargado { get; set; }

        public ProductoElectronico(int id, string nombre, int unidades, double precioUnidad, string descripcion, string material, bool pilas, bool precargado)
        : base(id, nombre, unidades, precioUnidad, descripcion)
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
