using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProveedorSOAP_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        ProveedorServiceReference.ProveedorWebService1SoapClient ws = new ProveedorServiceReference.ProveedorWebService1SoapClient();
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ws.GetProveedor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProveedorServiceReference.ProveedorWebService1SoapClient ws = new ProveedorServiceReference.ProveedorWebService1SoapClient();
            var resultado = ws.AgregarProveedor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (resultado == true)
                MessageBox.Show("Proveedor Agregado");
            else
                MessageBox.Show("Ocurrió un Error");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProveedorServiceReference.ProveedorWebService1SoapClient ws = new ProveedorServiceReference.ProveedorWebService1SoapClient();
            var resultado = ws.ActualizarProveedor(Convert.ToInt32(textBox5.Text), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (resultado == true)
                MessageBox.Show("Proveedor Actualizado");
            else
                MessageBox.Show("Ocurrió un Error");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProveedorServiceReference.ProveedorWebService1SoapClient ws = new ProveedorServiceReference.ProveedorWebService1SoapClient();
            var resultado = ws.BorrarProveedor(Convert.ToInt32(textBox5.Text));
            if (resultado == true)
                MessageBox.Show("Proveedor Eliminado");
            else
                MessageBox.Show("Ocurrió un Error");
        }
    }
}
