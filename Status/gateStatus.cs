using de_carga.Data_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de_carga.Valided_informations;
using System.Windows.Forms;

namespace de_carga.Status
{
    public class gateStatus
    {
        public string actualStatu {  get; set; }
        public string userChange {  get; set; }
        public string timeGateChange { get; set; }


        public void insertDataBase()
        {
            dataBase dataBase = new dataBase();
            userValided userValided = new userValided();
            dataBase.InsertGateStatu(timeGateChange, actualStatu, userChange);
        }

        public void loadTable(DataGridView grid)
        {
            dataBase dataBase = new dataBase();
            dataBase.LoadGateStatusIntoDataGridView(grid);
        }
    }
}
