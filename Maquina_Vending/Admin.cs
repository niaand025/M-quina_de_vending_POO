using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class Admin : Usuario
    {
        public Admin(int id, string nickName, string nombre, string ape1, string ape2, string password, List<Producto> ListaProductos) :
        base(id, nickName, nombre, ape1, ape2, password, ListaProductos)
        { }


        public override void Salir()
        {
            Console.WriteLine("Administrador ha salido.");
        }


        public override void Menu()
        {
            MaquinaVending maquinaVending = new MaquinaVending(ListaProductos);
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
                            maquinaVending.ComprarProdcuto();
                            break;

                        case 2:
                            maquinaVending.MostrarInformacionProducto();
                            break;

                        case 3:
                            maquinaVending.CargarProductosIndividualmente();
                            break;

                        case 4:
                            maquinaVending.CargarProductosDesdeArchivo("example_vending_file_practical_work_i.csv");
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


    }
}
