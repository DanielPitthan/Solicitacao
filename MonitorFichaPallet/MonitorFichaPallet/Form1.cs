using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorFichaPallet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewColumn ZD3_STATUS = new DataGridViewColumn(new DataGridViewTextBoxCell());
            DataGridViewColumn ZD3_CARGA = new DataGridViewColumn(new DataGridViewTextBoxCell());
            DataGridViewColumn ZD3_OP = new DataGridViewColumn(new DataGridViewTextBoxCell());
            DataGridViewColumn ZD3_COD = new DataGridViewColumn(new DataGridViewTextBoxCell());
            DataGridViewColumn ZD3_QUANT = new DataGridViewColumn(new DataGridViewTextBoxCell());

            ZD3_STATUS.HeaderText = "Id";
            ZD3_STATUS.Name = "id";
            ZD3_STATUS.Width = 50;
            ZD3_STATUS.ReadOnly = true;

            dgMonitor.Columns.Add(ZD3_STATUS);
            dgMonitor.Columns.Add(ZD3_CARGA);
            dgMonitor.Columns.Add(ZD3_OP);
            dgMonitor.Columns.Add(ZD3_COD);
            dgMonitor.Columns.Add(ZD3_QUANT);
            dgMonitor.Rows[1].Cells["ZD3_STATUS"].Style.BackColor = Color.Yellow;
        }
    }
}
