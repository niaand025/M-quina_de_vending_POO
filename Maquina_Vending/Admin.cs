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
    }
}
