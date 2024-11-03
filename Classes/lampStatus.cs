using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de_carga
{
    public class lampStatus
    {
        public string lamp1Status { get; set; }
        public string lamp2Status { get; set; }
        public string lamp3Status { get; set; }
        public string lamp4Status { get; set; }
        public DataGridView dgvLampStatus { get; set; }
        public DateTime timeLampChange { get; set; }
        dataBase DataBase =new dataBase();

        public void insertDataBase() {
            DataBase.InsertLampStatus(timeLampChange.ToString("hh:mm yyyy-MM-dd"),lamp1Status, lamp2Status, lamp3Status, lamp4Status);
            DataBase.LoadStatusIntoDataGridView("lampStatusRegist", dgvLampStatus);
            lamp1Status =null;
            lamp2Status=null;
            lamp3Status=null;
            lamp4Status=null;
        }        
    }
}
