using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCafeteria
{
    public partial class VentaProductos : Form
    {
        string correo;
        public VentaProductos(string s)
        {

            InitializeComponent();
            
            dataSet1.Clear();
            //dataSet1.ReadXml("d:\\ArchProductos.xml");
            dataSet1.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
            dataSet11.Clear();
            //dataSet11.ReadXml("d:\\ArchCliente.xml");
            dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");

            System.Data.DataRow[] dato;
            dato = dataSet11.tblCliente.Select("cedula='" + s + "'");
            lc.Text = dato[0]["cedula"].ToString();
            ln.Text = dato[0]["nombre"].ToString();
            le.Text = dato[0]["edad"].ToString();
            lg.Text = dato[0]["genero"].ToString();
            lem.Text = dato[0]["email"].ToString();
            lciu.Text = dato[0]["ciudad"].ToString();
            dataSet11.Clear();
            dataSet12.Clear();
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void agregarP_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            string s = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            string n = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            
            if (s == "")
            {
                MessageBox.Show("Selección de producto incorrecta");
            }
            else
            {
                Cantidad oc = new Cantidad();
                oc.ShowDialog();
                int x = oc.retornarNumero();
                double total;
                double num = double.Parse(n);
                total = x * num;
                dataGridView2.Rows.Add();
                int filas = dataGridView2.Rows.Count - 2;
                dataGridView2[0, filas].Value = s;
                dataGridView2[1, filas].Value = num.ToString();
                dataGridView2[2, filas].Value = x.ToString();
                dataGridView2[3, filas].Value = total.ToString();
                
            }
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection row = dataGridView2.SelectedRows;
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
               
            }
            catch
            {
                MessageBox.Show("Selección de fila incorrecta");
            }
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;
        }

        private void factura_Click(object sender, EventArgs e)
        {
            string mailBody = "";
            string dirCorreo;
            double suma_total = 0;
            double n;
            string s;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                s = Convert.ToString(row.Cells[3].Value);
                if (s != "")
                {
                    n = double.Parse(s);
                    suma_total = suma_total + n;
                }
            }

            if (suma_total == 0)
            {
                MessageBox.Show("Aún no ha ingresado productos");
            }
            else
            {
                factura.Visible = false;
                AgregarIva oi = new AgregarIva();
                oi.ShowDialog();
                int x = oi.retornarNumero();
                dataGridView2.Rows.Add(2);
                int filas = dataGridView2.Rows.Count - 3;

                dataGridView2[2, filas].Value = "Total sin iva";
                dataGridView2[3, filas].Value = suma_total.ToString();
                dataGridView2[2, (filas + 1)].Value = "Iva";
                dataGridView2[3, (filas + 1)].Value = (x + " %").ToString();
                dataGridView2[2, (filas + 2)].Value = "Total con iva";
                dataGridView2[3, (filas + 2)].Value = (suma_total + (calculo_iva(suma_total, x))).ToString();
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                dataGridView2.ClearSelection();
                dataGridView2.CurrentCell = null;
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;
                dirCorreo = lem.Text;
                correo = dirCorreo;
                l1.Text = DateTime.Now.ToString();
                CCorreo objCor = new CCorreo();
                MailMessage mensaje = new MailMessage();
                mensaje.To.Add(correo);
                mensaje.Subject = "CAFÉ MOLINO FACTURA";
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                mailBody += "<center><h2 style=background-color:#231C1D;color:#E8DDB5>" + "EcoAndes" + "</h2></center>";
                mailBody += "<center><h4 style=background-color:#E8DDB5;color:#231C1D>" + "Datos personales" + "</h4>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Nombre: </b>" + ln.Text +"</h5>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Cédula: </b>" + lc.Text +"</h5>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Edad: </b>" + le.Text +"</h5>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Género: </b>" + lg.Text +"</h5>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Ciudad: </b>" + lciu.Text +"</h5>";
                mailBody += "<center><h5 style=color:#231C1D;>" + "<b>Fecha y hora de la compra: </b>" + l1.Text +"</h5>";
                mailBody += "</br>";
                mailBody += "<h4 style=background-color:#E8DDB5;color:#231C1D>" + "Datos de la compra" + "</h4>";
                mailBody += "</br>";
                mailBody += "<center><td style=color:#231C1D;>" + "<b>Nombre del Producto</b>" + "</td>";
                mailBody += "<td style=color:#231C1D;>" + "<b>Precio Unitario</b>" + "</td>";
                mailBody += "<td style=color:#231C1D;>" + "<b>Cantidad</b>" + "</td>";
                mailBody += "<td style=color:#231C1D;>" + "<b>Total</b>" + "</td>";
                mailBody += "</br>";
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    mailBody += "<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        mailBody += "<td style=color:#231C1D;>" + cell.Value + "</td>";
                    }
                    mailBody += "</tr>";
                }
                mailBody += "</table>";
                mailBody += "</br>";
                mailBody += "</br>";
                mailBody += "<h4 style=color:#231C1D;>" + "Gracias por su compra!" + "";

                mensaje.Body = mailBody;
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.From = new MailAddress("cafemolinocafeteria@gmail.com");
                SmtpClient cliente = new SmtpClient();
                cliente.Credentials = new NetworkCredential("cafemolinocafeteria@gmail.com", "123456 MOLINO CAFE.");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";
                cliente.Send(mensaje);

                dataSet12.Clear();
                //dataSet12.ReadXml("d:\\ArchFactura.xml");
                dataSet12.ReadXml(Application.StartupPath + "\\ArchFactura.xml");
                string cod = lc.Text;
                string nom = ln.Text;
                string fechaHora = l1.Text;
                //string total = suma_total.ToString();
                string total = (suma_total + (calculo_iva(suma_total, x))).ToString();
                object[] dato3 = new object[4];
                dato3[0] = cod;
                dato3[1] = nom;
                dato3[2] = fechaHora;
                dato3[3] = total;
                dataSet12.tblFactura.Rows.Add(dato3);
                //dataSet12.WriteXml("d:\\ArchFactura.xml");
                dataSet12.WriteXml(Application.StartupPath + "\\ArchFactura.xml");
                MessageBox.Show("Se ha enviado correctamente la factura al correo del cliente");
                ven.Visible = true;
                
            }
            

        }
        public double calculo_iva(double t, double i)
        {
            double x;
            x = (t * i) / 100;
            return x;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void VentaProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;
        }

        private void ven_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;
        }
    }
}
