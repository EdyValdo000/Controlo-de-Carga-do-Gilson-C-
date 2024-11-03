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

using de_carga.Status;
using de_carga.Valided_informations;
using System.Security.Cryptography;


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
        String userName;
        public Form2(String UserName)
        {
            userName = UserName;
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

                timer1.Enabled = true;

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
                timer1.Enabled = false;

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
            gateStatus gateStatus = new gateStatus();
            gateStatus.userChange = userName;
            gateStatus.actualStatu = "Portão aberto";
            gateStatus.timeGateChange = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
            gateStatus.insertDataBase();

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
                gateStatus gateStatus = new gateStatus();
                gateStatus.userChange = userName;
                gateStatus.actualStatu = "Portão fechado";
                gateStatus.timeGateChange = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                gateStatus.insertDataBase();

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

        private void tabControl3_Click(object sender, EventArgs e)
        {
            lampStatus lampStatus = new lampStatus();
            lampStatus.loadTable(dgvLamp);

            gateStatus gateStatus = new gateStatus();
            gateStatus.loadTable(dgvGate);
        }

        bool flag1 = false, flag2 = false, flag3 = false, flag4 = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (tcpCliente.Connected)
            {
                try
                {
                    lampStatus lampStatus = new lampStatus();
                    gateStatus gateStatus = new gateStatus();

                    receber = strReceber.ReadLine();
                    string[] arduinoReturn = receber.Split('*');
                    this.Invoke(new MethodInvoker(delegate () { lampStatus.lamp1Statu = arduinoReturn[1].ToString(); }));
                    this.Invoke(new MethodInvoker(delegate () { lampStatus.lamp2Statu = arduinoReturn[2].ToString(); }));
                    this.Invoke(new MethodInvoker(delegate () { lampStatus.lamp3Statu = arduinoReturn[3].ToString(); }));
                    this.Invoke(new MethodInvoker(delegate () { lampStatus.lamp4Statu = arduinoReturn[4].ToString(); }));

                    this.Invoke(new MethodInvoker(delegate () { gateStatus.timeGateChange = arduinoReturn[4].ToString(); }));

                    this.Invoke(new MethodInvoker(delegate () {

                      
                        lampStatus.timeLampChange = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                        gateStatus.timeGateChange = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                        gateStatus.userChange = userName;


                        if (lampStatus.lamp1Statu == "Lamp1 ON")
                        {
                            flag1 = true;
                            pbLed4.Image = de_carga.Properties.Resources.foto2;
                        }
                        else if (lampStatus.lamp1Statu == "Lamp1 OFF")
                        {
                            flag1 = false;
                            pbLed4.Image = de_carga.Properties.Resources.foto1;
                        }

                        if (lampStatus.lamp2Statu == "Lamp2 ON")
                        {
                            flag2 = true;
                            pbLed4.Image = de_carga.Properties.Resources.foto2;
                        }
                        else if (lampStatus.lamp2Statu == "Lamp2 OFF")
                        {
                            flag2 = false;
                            pbLed4.Image = de_carga.Properties.Resources.foto1;
                        }

                        if (lampStatus.lamp3Statu == "Lamp3 ON")
                        {
                            flag3 = true;
                            pbLed4.Image = de_carga.Properties.Resources.foto2;
                        }
                        else if (lampStatus.lamp3Statu == "Lamp3 OFF")
                        {
                            flag3 = false;
                            pbLed4.Image = de_carga.Properties.Resources.foto1;
                        }

                        if (lampStatus.lamp4Statu == "Lamp4 ON")
                        {
                            flag4 = true;
                            pbLed4.Image = de_carga.Properties.Resources.foto2;
                        }
                        else if (lampStatus.lamp4Statu == "Lamp4 OFF")
                        {
                            flag4 = false;
                            pbLed4.Image = de_carga.Properties.Resources.foto1;
                        }

                        lampStatus.insertDataBase();
                        gateStatus.insertDataBase();
                    }));
                }
                catch
                {

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                stwEnviar.Write('s');
                stwEnviar.Flush();
            }
            catch (Exception)
            {

            }
        }
    }
}
