using de_carga.Data_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_carga.Valided_informations
{
    public class userValided
    {
        public string userName {  get; set; }
        public string password { get; set; }

        dataBase DataBase= new dataBase();
        private string _userName;
        private string _password;
        public bool valided() { 
            _userName = this.userName;
            _password = this.password;
            return DataBase.ValidateUserCredentials(_userName, _password);
        }

    }
}
