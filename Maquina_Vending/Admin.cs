using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class Admin : Usuario
    {
        public Admin(int id, string nickName, string nombre, string ape1, string ape2, string password) :
        base(id, nickName, nombre, ape1, ape2, password)
        { 

        }

        public override void Salir()
        {
            Console.WriteLine("Administrador ha salido.");
        }
        // Métodos adicionales específicos para el administrador
        public void AgregarProducto()
        {
            // Lógica para agregar un nuevo producto
            Console.WriteLine("Se agregó un nuevo producto.");
        }

        public void EliminarProducto()
        {
            // Lógica para eliminar un producto existente
            Console.WriteLine("Se eliminó un producto.");
        }


        public override void Menu()
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


    }
}
