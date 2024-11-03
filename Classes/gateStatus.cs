using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_carga
{
    public class gateStatus
    {
        public string userGateChaged {  get; set; }
        public string gateActualStatu { get; set; }        
        public DateTime timeGateChanged { get; set; }

        dataBase DataBase=new dataBase();
    }
}
