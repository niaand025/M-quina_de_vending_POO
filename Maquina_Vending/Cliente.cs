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
        

        public void ComprarProducto()
        {

        }

        public override void Salir()
        {
            // Almacenar la lista de contenidos en contenido.txt
            if (listaContenidos.Count > 0) // Si hay contenidos en la lista...
            {
                using (StreamWriter sw = new StreamWriter("contenidos.txt", true))
                {
                    foreach (Contenido c in listaContenidos)
                    {
                        c.ToFile(); // Guardamos cada contenido en el archivo
                    }
                }
            }
        }
    }
}
