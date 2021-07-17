
namespace eAgenda.WindowsFormsApp
{
    partial class VisualizarTarefasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarTarefasForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDeCriacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDeConclusaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tdsRadio = new System.Windows.Forms.RadioButton();
            this.cmpRadio = new System.Windows.Forms.RadioButton();
            this.pendRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.dataDeCriacaoDataGridViewTextBoxColumn,
            this.dataDeConclusaoDataGridViewTextBoxColumn,
            this.prioridadeDataGridViewTextBoxColumn,
            this.porcentualDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Table1";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Location = new System.Drawing.Point(25, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(736, 264);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            // 
            // dataDeCriacaoDataGridViewTextBoxColumn
            // 
            this.dataDeCriacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataDeCriacaoDataGridViewTextBoxColumn.DataPropertyName = "Data de Criacao";
            this.dataDeCriacaoDataGridViewTextBoxColumn.HeaderText = "Data de Criacao";
            this.dataDeCriacaoDataGridViewTextBoxColumn.Name = "dataDeCriacaoDataGridViewTextBoxColumn";
            // 
            // dataDeConclusaoDataGridViewTextBoxColumn
            // 
            this.dataDeConclusaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataDeConclusaoDataGridViewTextBoxColumn.DataPropertyName = "Data de Conclusao";
            this.dataDeConclusaoDataGridViewTextBoxColumn.HeaderText = "Data de Conclusao";
            this.dataDeConclusaoDataGridViewTextBoxColumn.Name = "dataDeConclusaoDataGridViewTextBoxColumn";
            // 
            // prioridadeDataGridViewTextBoxColumn
            // 
            this.prioridadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prioridadeDataGridViewTextBoxColumn.DataPropertyName = "Prioridade";
            this.prioridadeDataGridViewTextBoxColumn.HeaderText = "Prioridade";
            this.prioridadeDataGridViewTextBoxColumn.Name = "prioridadeDataGridViewTextBoxColumn";
            // 
            // porcentualDataGridViewTextBoxColumn
            // 
            this.porcentualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.porcentualDataGridViewTextBoxColumn.DataPropertyName = "Porcentual";
            this.porcentualDataGridViewTextBoxColumn.HeaderText = "Porcentual";
            this.porcentualDataGridViewTextBoxColumn.Name = "porcentualDataGridViewTextBoxColumn";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Id";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Titulo";
            this.dataColumn2.ColumnName = "Titulo";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Data de Criacao";
            this.dataColumn3.ColumnName = "Data de Criacao";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Data de Conclusao";
            this.dataColumn4.ColumnName = "Data de Conclusao";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Prioridade";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Porcentual";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(273, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 93);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // tdsRadio
            // 
            this.tdsRadio.AutoSize = true;
            this.tdsRadio.Checked = true;
            this.tdsRadio.Location = new System.Drawing.Point(25, 122);
            this.tdsRadio.Name = "tdsRadio";
            this.tdsRadio.Size = new System.Drawing.Size(55, 17);
            this.tdsRadio.TabIndex = 12;
            this.tdsRadio.TabStop = true;
            this.tdsRadio.Text = "Todos";
            this.tdsRadio.UseVisualStyleBackColor = true;
            this.tdsRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tdsRadio_MouseClick);
            // 
            // cmpRadio
            // 
            this.cmpRadio.AutoSize = true;
            this.cmpRadio.Location = new System.Drawing.Point(125, 122);
            this.cmpRadio.Name = "cmpRadio";
            this.cmpRadio.Size = new System.Drawing.Size(74, 17);
            this.cmpRadio.TabIndex = 13;
            this.cmpRadio.Text = "Cumpridas";
            this.cmpRadio.UseVisualStyleBackColor = true;
            this.cmpRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmpRadio_MouseClick);
            // 
            // pendRadio
            // 
            this.pendRadio.AutoSize = true;
            this.pendRadio.Location = new System.Drawing.Point(236, 122);
            this.pendRadio.Name = "pendRadio";
            this.pendRadio.Size = new System.Drawing.Size(76, 17);
            this.pendRadio.TabIndex = 14;
            this.pendRadio.Text = "Pendentes";
            this.pendRadio.UseVisualStyleBackColor = true;
            this.pendRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pendRadio_MouseClick);
            // 
            // VisualizarTarefasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pendRadio);
            this.Controls.Add(this.cmpRadio);
            this.Controls.Add(this.tdsRadio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VisualizarTarefasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualizarTarefasForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VisualizarTarefasForm_FormClosed);
            this.Load += new System.EventHandler(this.VisualizarTarefasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton tdsRadio;
        private System.Windows.Forms.RadioButton cmpRadio;
        private System.Windows.Forms.RadioButton pendRadio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDeCriacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDeConclusaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentualDataGridViewTextBoxColumn;
        private System.Data.DataColumn dataColumn6;
    }
}