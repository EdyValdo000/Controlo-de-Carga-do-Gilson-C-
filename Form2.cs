using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace de_carga
{
    public partial class Form2 : Form
    {
        private TcpClient tcpCliente;
        private IPAddress enderecoIP;
        private StreamWriter stwEnviar;
        private StreamReader strReceber;
        private Int16 Porta;
        private String receber;
        public Form2()
        {
           
            InitializeComponent();
        }

        private void btCConectar_Click(object sender, EventArgs e)
        {
            try
            {
                enderecoIP = IPAddress.Parse(tbEnderecoIP.Text);
                Porta = Convert.ToInt16(tbPorta.Text);

                tcpCliente = new TcpClient();
                tcpCliente.Connect(enderecoIP, Porta);

                tbEnderecoIP.Enabled = false;
                tbPorta.Enabled = false;
                btCConectar.Enabled = false;
                btFechar.Enabled = false;
                btDesconectar.Enabled = true;

                stwEnviar = new StreamWriter(tcpCliente.GetStream());
                strReceber = new StreamReader(tcpCliente.GetStream());
                stwEnviar.Flush();

                LbMsgPorta.Text = "PORTA ABERTA";
                LbMsgPorta.ForeColor = Color.Green;

            }
            
            catch(Exception)
           
            {
                MessageBox.Show("Insira novamente os parametros!");
            }


        }

        private void btDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Close();
                strReceber.Close();
                tcpCliente.Close();
                tbEnderecoIP.Enabled = true;
                tbPorta.Enabled = true;
                btCConectar.Enabled = true;
                btFechar.Enabled = true;
                btDesconectar.Enabled = false;

                LbMsgPorta.Text = "PORTA FECHADA";
                LbMsgPorta.ForeColor = Color.Red;
            }
            catch
            {
            }


        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
               
                stwEnviar.Write('1');
                pbLed1.Image = de_carga.Properties.Resources.foto2;
                btLed1on.Enabled = false;
                btLed1off.Enabled = true;
                btLedoffall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed1off_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('2');
                pbLed1.Image = de_carga.Properties.Resources.foto1;
                btLed1on.Enabled = true;
                btLed1off.Enabled = false;
                btLedonall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed2on_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('3');
                pbLed2.Image = de_carga.Properties.Resources.foto2;
                btLed2on.Enabled = false;
                btLed2off.Enabled = true;
                btLedoffall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed2off_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('4');
                pbLed2.Image = de_carga.Properties.Resources.foto1;
                btLed2on.Enabled = true;
                btLed2off.Enabled = false;
                btLedonall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed3off_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('6');
                pbLed3.Image = de_carga.Properties.Resources.foto1;
                btLed3on.Enabled = true;
                btLed3off.Enabled = false;
                btLedonall.Enabled = true;

                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed3on_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('5');
                pbLed3.Image = de_carga.Properties.Resources.foto2;
                btLed3on.Enabled = false;
                btLed3off.Enabled = true;
                btLedoffall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed4on_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('7');
                pbLed4.Image = de_carga.Properties.Resources.foto2;
                btLed4on.Enabled = false;
                btLed4off.Enabled = true;
                btLedoffall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLed4off_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('8');
                pbLed4.Image = de_carga.Properties.Resources.foto1;
                btLed4on.Enabled = true;
                btLed4off.Enabled = false;
                btLedonall.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLedonall_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('9');
                pbLed1.Image = de_carga.Properties.Resources.foto2;
                pbLed2.Image = de_carga.Properties.Resources.foto2;
                pbLed3.Image = de_carga.Properties.Resources.foto2;
                pbLed4.Image = de_carga.Properties.Resources.foto2;
                btLedonall.Enabled = false;
                btLedoffall.Enabled = true;
                btLed1off.Enabled = true;
                btLed2off.Enabled = true;
                btLed3off.Enabled = true;
                btLed4off.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btLedoffall_Click(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('0');
                pbLed1.Image = de_carga.Properties.Resources.foto1;
                pbLed2.Image = de_carga.Properties.Resources.foto1;
                pbLed3.Image = de_carga.Properties.Resources.foto1;
                pbLed4.Image = de_carga.Properties.Resources.foto1;
                btLedonall.Enabled = true;
                btLedoffall.Enabled = false;
                btLed1on.Enabled = true;
                btLed2on.Enabled = true;
                btLed3on.Enabled = true;
                btLed4on.Enabled = true;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void pbLed1_Click(object sender, EventArgs e)
        {

        }

        private void LbMsgPorta_Click(object sender, EventArgs e)
        {

        }

        private void pbLed3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {

                stwEnviar.Write('a');
                

                btfcport.Enabled = true;
                button15.Enabled = false;
                lbportaocl.Text = "PORTÃO ABERTO";
                lbportaocl.ForeColor = Color.Green;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }

        private void btfcport_Click(object sender, EventArgs e)
        {
            try
            {

                stwEnviar.Write('b');
             
                button15.Enabled = true;
                btfcport.Enabled = false;
                lbportaocl.Text = "PORTA FECHADA";
                lbportaocl.ForeColor = Color.Red;
                stwEnviar.Flush();


            }
            catch
            {

            }
        }
    }
}
