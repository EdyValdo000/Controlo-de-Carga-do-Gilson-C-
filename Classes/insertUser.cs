using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_carga.Classes
{
    public class insertUser
    {
        public insertUser(string nameUser, string passwordUser)
        {
            dataBase dataBase1 = new dataBase();
            dataBase1.InsertUser(nameUser, passwordUser);
        }
    }
}
