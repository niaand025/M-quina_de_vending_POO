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

        public MaquinaVending(List<Producto> productos)
        {
            listaProductos = productos;
        }

        public void ComprarProdcuto(Usuario usuario)
        {
            MostrarProductosDisponibles();
            Console.Write("Ingrese el ID del producto que desea comprar: ");
            int idProducto = int.Parse(Console.ReadLine());
            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            //Verificar si el  prodcuto existe
            if(productoSeleccionado != null)
            {
                // Mostrar la información del producto seleccionado
                Console.WriteLine("Información del producto seleccionado:");
                productoSeleccionado.MostrarInformacion();

                // Solicitar al usuario que elija el método de pago
                Console.WriteLine("Seleccione el método de pago:");
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                try
                {
                    switch (opcion)
                    {
                        case 1:
                            if (PagoEfectivo(productoSeleccionado))
                            {
                                Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                productoSeleccionado.Unidades--; // Disminuir las unidades del producto
                            }
                            else
                            {
                                Console.WriteLine("El pago en efectivo no fue suficiente.");
                            }
                            break;
                        case 2:
                            if (PagoTarjeta())
                            {
                                Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                productoSeleccionado.Unidades--; // Disminuir las unidades del producto
                            }
                            else
                            {
                                Console.WriteLine("El pago con tarjeta fue rechazado.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción de pago no válida.");
                            break;
                    } while (opcion != 3) ;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Opción invalida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            }  
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
            
        }
        
        public void MostrarProductosDisponibles()
        {
            Console.WriteLine("Productos disponibles:");
            foreach (Producto producto in listaProductos)
            {
                Console.WriteLine($"{producto.Id}: {producto.Nombre}");
            }
        }
        private bool PagoEfectivo(Producto producto)
        {
            Console.WriteLine($"El precio del producto es: {producto.PrecioUnidad}");
            Console.WriteLine("Por favor, ingrese el monto en efectivo:");

            double montoIngresado = 0;
            while (montoIngresado < producto.PrecioUnidad)
            {
                Console.Write("Ingrese una moneda: ");
                double moneda = double.Parse(Console.ReadLine());
                montoIngresado += moneda;
            }

            return montoIngresado >= producto.PrecioUnidad;
        }

        private bool PagoTarjeta()
        {
            Console.WriteLine("Ingrese los datos de su tarjeta:");
            Console.Write("Número de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Fecha de caducidad (MM/AA): ");
            string fechaCaducidad = Console.ReadLine();
            Console.Write("Código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            // Supongamos que siempre aceptamos el pago con tarjeta
            return true;
        }

        //---------------------------------------------------------------------------------------------------------
        public void MostrarInformacionProducto()
        {
            // Mostrar los productos disponibles
            MostrarProductosDisponibles();

            // Solicitar al usuario que ingrese el ID del producto del que desea ver la información
            Console.Write("Ingrese el ID del producto del que desea ver la información: ");
            int idProducto = int.Parse(Console.ReadLine());

            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            // Verificar si el producto existe
            if (productoSeleccionado != null)
            {
                // Mostrar la información del producto seleccionado
                Console.WriteLine("Información del producto seleccionado:");
                productoSeleccionado.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }

    }
}
