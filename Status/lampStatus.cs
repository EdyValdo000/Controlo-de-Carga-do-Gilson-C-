using de_carga.Data_Base;
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
        public string lamp1Statu{get;set;}
        public string lamp2Statu { get; set; }
        public string lamp3Statu { get; set; }
        public string lamp4Statu { get; set; }
        public string timeLampChange { get; set; }

        public void insertDataBase()
        {
            dataBase dataBase = new dataBase();
            dataBase.InsertLampStatus(timeLampChange,lamp1Statu,lamp2Statu,lamp3Statu,lamp4Statu);
        }

        public void loadTable(DataGridView grid)
        {
            dataBase dataBase = new dataBase();
            dataBase.LoadLampStatusIntoDataGridView(grid);
        }
    }
}
