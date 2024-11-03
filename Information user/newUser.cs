using de_carga.Data_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_carga.Information_user
{
    public class newUser
    {
        public string userName { get; set; }
        public string password { get; set; }

        dataBase database = new dataBase();
        private string _userName;
        private string _password;

        public void newCount() 
        {
            _userName=userName;
            _password=password;
            userName = null;
            password = null;
            database.InsertUser(_userName, _password);
        }
    }
}
