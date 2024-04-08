using System;
using System.Collections.Generic;

namespace Maquina_Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una instancia de la máquina de vending
            VendingMachine maquina = new VendingMachine();

            // Agregamos algunos productos a la máquina
            maquina.AgregarProducto(new Producto("Refresco", 1.50m));
            maquina.AgregarProducto(new Producto("Agua", 1.00m));
            maquina.AgregarProducto(new Producto("Snack", 2.00m));

            Console.WriteLine("Bienvenido a la máquina de vending.");

            while (true)
            {
                // Mostramos los productos disponibles
                Console.WriteLine("\nProductos disponibles:");
                foreach (Producto producto in maquina.ProductosDisponibles())
                {
                    Console.WriteLine($"{producto.Nombre} - {producto.Precio:C}");
                }

                // Solicitamos al usuario que seleccione un producto
                Console.Write("\nSeleccione el número del producto que desea comprar (o 0 para salir): ");
                int seleccion;
                while (!int.TryParse(Console.ReadLine(), out seleccion) || seleccion < 0 || seleccion > maquina.NumeroDeProductos())
                {
                    Console.WriteLine("Selección inválida. Intente de nuevo.");
                }

                if (seleccion == 0)
                    break;

                // Realizamos la compra del producto seleccionado
                Producto productoSeleccionado = maquina.ObtenerProducto(seleccion);

                // Solicitamos al usuario que ingrese monedas
                Console.Write($"Inserte {productoSeleccionado.Precio:C} en monedas: ");
                decimal montoIngresado;
                while (!decimal.TryParse(Console.ReadLine(), out montoIngresado) || montoIngresado < productoSeleccionado.Precio)
                {
                    Console.WriteLine("Monto insuficiente. Intente de nuevo.");
                }

                // Realizamos la compra y mostramos el cambio si es necesario
                decimal cambio = maquina.ComprarProducto(productoSeleccionado, montoIngresado);
                if (cambio > 0)
                {
                    Console.WriteLine($"Gracias por su compra. Su cambio es {cambio:C}");
                }
                else
                {
                    Console.WriteLine("Gracias por su compra. No hay cambio.");
                }
            }
        }
    }

    // Clase para representar un producto en la máquina de vending
    class Producto
    {
        public string Nombre { get; }
        public decimal Precio { get; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }

    // Clase para representar la máquina de vending
    class VendingMachine
    {
        private List<Producto> productos = new List<Producto>();

        // Agregar un producto a la máquina
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        // Obtener la lista de productos disponibles
        public List<Producto> ProductosDisponibles()
        {
            return productos;
        }

        // Obtener el número total de productos en la máquina
        public int NumeroDeProductos()
        {
            return productos.Count;
        }

        // Obtener un producto por su número de selección
        public Producto ObtenerProducto(int seleccion)
        {
            return productos[seleccion - 1];
        }

        // Realizar la compra de un producto
        public decimal ComprarProducto(Producto producto, decimal montoIngresado)
        {
            decimal cambio = montoIngresado - producto.Precio;
            if (cambio >= 0)
            {
                // Restar el producto de la máquina
                productos.Remove(producto);
                return cambio;
            }
            else
            {
                // No hay suficiente dinero ingresado
                return -1;
            }
        }
    }
}
