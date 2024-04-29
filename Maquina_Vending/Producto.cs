using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal abstract class Producto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public float PrecioUnidad { get; set; }
        public string Descripcion { get; set; }

        public Producto(int id, string nombre, int unidades, float precioUnidad, string descripcion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Unidades = unidades;
            this.PrecioUnidad = precioUnidad;
            this.Descripcion = descripcion;
        }
        public Producto(int id)
        {
            this.Id = id;
        }

        public abstract void MostrarInformacion();
        public virtual void SolicitarInformación()
        {
            // Solicitar al usuario que ingrese los detalles del nuevo producto
            Console.WriteLine("Ingrese los detalles del nuevo producto:");

            Console.Write("Nombre del producto: ");
            this.Nombre = Console.ReadLine();

            Console.Write("Unidades disponibles: ");
            this.Unidades = int.Parse(Console.ReadLine());

            Console.Write("Precio por unidad: ");
            this.PrecioUnidad = float.Parse(Console.ReadLine());

            Console.Write("Descripción del producto: ");
            this.Descripcion = Console.ReadLine();

            // Determinar el tipo de producto (materiales preciosos, productos alimenticios, productos electrónicos)
        }


    }
}
