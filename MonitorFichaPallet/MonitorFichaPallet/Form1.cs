using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorFichaPallet.Helpers;
using System.Threading;

namespace MonitorFichaPallet
{
    public partial class Form1 : Form
    {
        public BindingSource binding = new BindingSource();
        public Font oFontg = new Font(new FontFamily("Calibri"), 14);
        public Font oFonth = new Font(new FontFamily("Calibri"), 14, FontStyle.Bold);
        public CancellationTokenSource tcancel = new CancellationTokenSource();
        public int time = 60000;

        string query = "SELECT	TOP 300 ZD3_STATUS  as [Status],	    Cast(ZD3_EMISSA as Date)  as [Emissão],	        ZD3_HORA    as [Hora]," +
                                 " ZD3_SEQ           as [Sequência],	    ZD3_COD     as [Produto],	        ZD3_OP      as [OP]," +
                                 " ZD3_LOTECT        as [Lote], 	        ZD3_NFICHA  as [Ficha Pallet],	    ZD3_CARGA   as [Carga]," +
                                 " ZD3_NF            as [Nota Fiscal],   ZD3_QTDLID  as [Quantidade Lida],	ZD3_QUANT   as [Quantidade Apontada]" +
                                 " FROM  ZD3010" +
                                 " WHERE D_E_L_E_T_ = ''";

        public Form1()
        {    
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dgMonitor.ColumnHeadersDefaultCellStyle.Font = oFonth;
            

            CarregaDados();
            CarregaDadosasync();
            Tempoasync();
          

        }

        private async void Tempoasync()
        {
           


            while (true)
            {
                //Inicia uma  Tarefa
                try
                {
                    await Task.Delay(60, tcancel.Token);
                }
                catch (TaskCanceledException ex)
                {
                    //Verifica se a task foi cancelada 
                    if (tcancel.IsCancellationRequested)
                    {
                        tcancel.Dispose();
                        tcancel = new CancellationTokenSource();
                        Thread.Sleep(2000); //Da um tempinho para parar a thread, dá só uma seguradinha fera                    
                    }
                }

                
                lbtime.Text = Convert.ToString(DateTime.Now);
            }
        }



        private async void CarregaDadosasync()
        {
            while (true)
            {
                //Inicia uma  Tarefa
                try
                {
                    await Task.Delay(time, tcancel.Token);
                }
                catch (TaskCanceledException ex)
                {
                    //Verifica se a task foi cancelada 
                    if (tcancel.IsCancellationRequested)
                    {
                        tcancel.Dispose();
                        tcancel = new CancellationTokenSource();
                        Thread.Sleep(2000); //Da um tempinho para parar a thread, dá só uma seguradinha fera                    
                    }
                }

                CarregaDados();
            }
            
        }

        /// <summary>
        /// Método responsável por carregar os dados na grid
        /// </summary>
        private void CarregaDados()
        {
           

                using (IDbConnection conexao = ConnectionFactory.CriaConexao())
                using (IDbCommand comando = conexao.CreateCommand())
                {
                   
                    comando.CommandText = query;
                    IDataReader leitor = comando.ExecuteReader();
                    binding.DataSource = leitor;
                    dgMonitor.DataSource = binding;
                }
            

        }


        private void FormataGrid(object sender, EventArgs e)
        {
            dgMonitor.Columns["Status"].Width = 120;
            dgMonitor.Columns["Emissão"].Width = 120;
            dgMonitor.Columns["Sequência"].Width = 120;
            dgMonitor.Columns["Lote"].Width = 120;
            dgMonitor.Columns["Produto"].Width = 150;
            dgMonitor.Columns["Ficha Pallet"].Width = 120;
            dgMonitor.Columns["OP"].Width = 150;
            dgMonitor.Columns["Nota Fiscal"].Width = 120;
            dgMonitor.Columns["Quantidade Lida"].Width = 180;
            dgMonitor.Columns["Quantidade Apontada"].Width = 230;


        }

        private void formatagrid2(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString().Trim() == "DEVOLVIDO")
            {                
                dgMonitor.Rows[e.RowIndex].Cells["Status"].Style.BackColor = Color.OrangeRed;
            }                  
                               
            if (dgMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString().Trim() == "EXPEDICAO")
            {                  
                dgMonitor.Rows[e.RowIndex].Cells["Status"].Style.BackColor = Color.DeepSkyBlue;
            }                  
                               
            if (dgMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString().Trim() == "RECEBIDO")
            {                  
                dgMonitor.Rows[e.RowIndex].Cells["Status"].Style.BackColor = Color.GreenYellow;
            }                  
            if (dgMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString().Trim() == "TRANSITO")
            {                  
                dgMonitor.Rows[e.RowIndex].Cells["Status"].Style.BackColor = Color.Gold;
            }


            dgMonitor.Rows[e.RowIndex].Height = 50;

            dgMonitor.Rows[e.RowIndex].Cells["Status"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Emissão"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Hora"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Sequência"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Produto"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["OP"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Lote"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Ficha Pallet"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Carga"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Nota Fiscal"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Quantidade Lida"].Style.Font = oFontg;
            dgMonitor.Rows[e.RowIndex].Cells["Quantidade Apontada"].Style.Font = oFontg;
        }
    }

    

}

