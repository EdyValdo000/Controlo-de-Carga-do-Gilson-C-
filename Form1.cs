using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using de_carga.Valided_informations;
using de_carga.Data_Base;
using de_carga.Information_user;
using de_carga.Status;

namespace de_carga
{
    public partial class Form1 : Form
    {
        Thread nt ;
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            userValided userValided = new userValided();
            userValided.userName = tbUserName.Text;
            userValided.password = tbPassword.Text;
            

            if (userValided.valided())
            {
                Form2 form2 = new Form2(tbUserName.Text);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Senha invalida! please try again.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            newUser newUser = new newUser();
            newUser.userName = tbUserName.Text;
            newUser.password = tbPassword.Text;
            newUser.newCount();
        }
    }
}


//lampStatus lampStatus = new lampStatus();
//lampStatus.lamp1Statu = "lamp1 ON";
//lampStatus.lamp2Statu = "lamp2 OFF";
//lampStatus.lamp3Statu = "lamp3 OFF";
//lampStatus.lamp4Statu = "lamp4 ON";
//lampStatus.timeLampChange = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
//lampStatus.insertDataBase();