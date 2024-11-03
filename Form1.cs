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
        userValided userValided = new userValided();
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            userValided.userName = tbUserName.Text;
            userValided.password = tbPassword.Text;
            

            if (userValided.valided())
            {
                Form2 form2 = new Form2(userValided);
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