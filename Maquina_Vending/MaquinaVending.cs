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

        /*------------------------------------------*/


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
}
