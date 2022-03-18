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
    }
}
