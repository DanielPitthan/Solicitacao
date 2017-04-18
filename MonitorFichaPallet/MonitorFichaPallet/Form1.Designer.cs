namespace MonitorFichaPallet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgMonitor = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtime = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkbDevolvidos = new System.Windows.Forms.CheckBox();
            this.checkbExpedidos = new System.Windows.Forms.CheckBox();
            this.checkbTransito = new System.Windows.Forms.CheckBox();
            this.checkbRecebido = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitor)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMonitor
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgMonitor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMonitor.Location = new System.Drawing.Point(3, 53);
            this.dgMonitor.Name = "dgMonitor";
            this.dgMonitor.Size = new System.Drawing.Size(1246, 492);
            this.dgMonitor.TabIndex = 0;
            this.dgMonitor.DataSourceChanged += new System.EventHandler(this.FormataGrid);
            this.dgMonitor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.formatagrid2);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgMonitor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 604);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbtime, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1246, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MonitorFichaPallet.Properties.Resources.pallet1;
            this.pictureBox1.InitialImage = global::MonitorFichaPallet.Properties.Resources.Monitor_Screen_32xLG;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movimentação de Pallets";
            // 
            // lbtime
            // 
            this.lbtime.AutoSize = true;
            this.lbtime.Location = new System.Drawing.Point(1099, 0);
            this.lbtime.Name = "lbtime";
            this.lbtime.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lbtime.Size = new System.Drawing.Size(10, 23);
            this.lbtime.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkbDevolvidos);
            this.flowLayoutPanel1.Controls.Add(this.checkbExpedidos);
            this.flowLayoutPanel1.Controls.Add(this.checkbTransito);
            this.flowLayoutPanel1.Controls.Add(this.checkbRecebido);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 551);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1246, 50);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // checkbDevolvidos
            // 
            this.checkbDevolvidos.AutoSize = true;
            this.checkbDevolvidos.Location = new System.Drawing.Point(3, 3);
            this.checkbDevolvidos.Name = "checkbDevolvidos";
            this.checkbDevolvidos.Size = new System.Drawing.Size(79, 17);
            this.checkbDevolvidos.TabIndex = 0;
            this.checkbDevolvidos.Text = "Devolvidos";
            this.checkbDevolvidos.UseVisualStyleBackColor = true;
            this.checkbDevolvidos.Click += new System.EventHandler(this.FiltraDevolvidos);
            // 
            // checkbExpedidos
            // 
            this.checkbExpedidos.AutoSize = true;
            this.checkbExpedidos.Location = new System.Drawing.Point(88, 3);
            this.checkbExpedidos.Name = "checkbExpedidos";
            this.checkbExpedidos.Size = new System.Drawing.Size(75, 17);
            this.checkbExpedidos.TabIndex = 1;
            this.checkbExpedidos.Text = "Expedidos";
            this.checkbExpedidos.UseVisualStyleBackColor = true;
            this.checkbExpedidos.Click += new System.EventHandler(this.FiltraExpedidos);
            // 
            // checkbTransito
            // 
            this.checkbTransito.AutoSize = true;
            this.checkbTransito.Location = new System.Drawing.Point(169, 3);
            this.checkbTransito.Name = "checkbTransito";
            this.checkbTransito.Size = new System.Drawing.Size(64, 17);
            this.checkbTransito.TabIndex = 2;
            this.checkbTransito.Text = "Trânsito";
            this.checkbTransito.UseVisualStyleBackColor = true;
            this.checkbTransito.Click += new System.EventHandler(this.FiltraTransito);
            // 
            // checkbRecebido
            // 
            this.checkbRecebido.AutoSize = true;
            this.checkbRecebido.Location = new System.Drawing.Point(239, 3);
            this.checkbRecebido.Name = "checkbRecebido";
            this.checkbRecebido.Size = new System.Drawing.Size(72, 17);
            this.checkbRecebido.TabIndex = 3;
            this.checkbRecebido.Text = "Recebido";
            this.checkbRecebido.UseVisualStyleBackColor = true;
            this.checkbRecebido.Click += new System.EventHandler(this.FiltraRecebido);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Movimentação de Pallet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitor)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMonitor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkbDevolvidos;
        private System.Windows.Forms.CheckBox checkbExpedidos;
        private System.Windows.Forms.CheckBox checkbTransito;
        private System.Windows.Forms.CheckBox checkbRecebido;
    }
}

