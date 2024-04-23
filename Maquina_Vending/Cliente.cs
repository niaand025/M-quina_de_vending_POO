using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class Cliente : Usuario
    {
        public Cliente(int idu, string nickName, string nombre, string ape1, string ape2, string password) :
        base(idu, nickName, nombre, ape1, ape2, password)
        {
           
        }
        public override void Salir()
        {
            Console.WriteLine("Administrador ha salido.");
        }

        public void ComprarProducto()
        {

        }
        
        public override void Menu()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.- Comprar un producto");
                Console.WriteLine("2.- Mostrar información del producto");                
                Console.WriteLine("3.- salir");
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
