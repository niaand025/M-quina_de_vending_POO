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

        public ProductoAlimenticio(int id, string nombre, int unidades, float precioUnidad, string descripcion, string informacion)
        : base(id, nombre, unidades, precioUnidad, descripcion)
        {
            this.Informacion = informacion;            
        }
        public ProductoAlimenticio(int id) : base(id) { }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: {PrecioUnidad}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Unidades disponibles: {Unidades}");
            Console.WriteLine($"Información nutricional: {Informacion}");
            
        }
        public override void SolicitarInformación()
        {
            base.SolicitarInformación();
            Console.Write("Información nutricional: ");
            this.Informacion = Console.ReadLine();
        }

    }
}
