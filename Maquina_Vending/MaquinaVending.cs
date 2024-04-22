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
        public void Menu()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.- Comprar un producto");
                Console.WriteLine("2.- Mostrar productos");
                Console.WriteLine("3.- Carga individual de productos");
                Console.WriteLine("4.- Carga completa de productos");
                Console.WriteLine("5.- salir");
                Console.WriteLine("Opción: ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:

                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;

                        case 5:
                            Console.WriteLine("Saleindo...");
                            break;

                        default:
                            Console.WriteLine("Opción no valida");
                            break;
                    }
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
            } while (opcion != 5);
        }
        public void AgregarProducto(Producto productos)
        {
            listaProductos.Add(productos);
        }
        public void MostrarProductos()
        {
            foreach (var productos in listaProductos)
            {
                productos.MostrarInformacion();
                Console.WriteLine();
            }
        }
        public void ComprarProducto(int indice)
        {
            if (indice >= 0 && indice < listaProductos.Count)
            {
                if (listaProductos[indice].Unidades > 0)
                {
                    Console.WriteLine($"Has comprado {listaProductos[indice].Nombre} por {listaProductos[indice].PrecioUnidad}");
                    listaProductos[indice].Unidades--;
                }
                else
                {
                    Console.WriteLine("Producto no disponible.");
                }
            }
            else
            {
                Console.WriteLine("Índice de producto inválido.");
            }
        }
        public void CargarProductosDesdeArchivo(string rutaArchivo)
        {
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(';');
                        // Analizar los datos y crear el producto correspondiente
                        // Agregar el producto a la lista de productos
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar productos desde el archivo: {ex.Message}");
            }
        }
}
