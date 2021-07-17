
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp
{
    partial class InserirTarefaForm
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

        private void Eventos()
        {
            tiruloField.Leave += new EventHandler(CampoSaiu);
            dataPicker.Leave += new EventHandler(CampoSaiu);
            percentField.Leave += new EventHandler(CampoSaiu);
            priorField.Leave += new EventHandler(CampoSaiu);
        }

        public void CampoSaiu(object sender, EventArgs e)
        {
            if (sender is Control txt) //MaskedTextBox, TextBox
            {
                if (txt.Text.Length == 0)
                {
                    txt.TabStop = true;
                    txt.BackColor = Color.LightCoral;
                    AddButton.Enabled = false;
                }
                else
                {
                    txt.TabStop = false;
                    txt.BackColor = Color.Green;
                    AddButton.Enabled = VerificarCamposNulos();
                }
            }

        }

        private bool VerificarCamposNulos()
        {
            if (tiruloField.Text.EhVazia() || dataPicker.Text.EhVazia() || percentField.Text.EhVazia() || priorField.Text.EhVazia())
                return false;
            return true;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InserirTarefaForm));
            this.tiruloField = new System.Windows.Forms.TextBox();
            this.percentField = new System.Windows.Forms.TextBox();
            this.priorField = new System.Windows.Forms.TextBox();
            this.dataPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tiruloField
            // 
            this.tiruloField.Location = new System.Drawing.Point(134, 99);
            this.tiruloField.Name = "tiruloField";
            this.tiruloField.Size = new System.Drawing.Size(209, 20);
            this.tiruloField.TabIndex = 1;
            // 
            // percentField
            // 
            this.percentField.Location = new System.Drawing.Point(134, 176);
            this.percentField.Name = "percentField";
            this.percentField.Size = new System.Drawing.Size(209, 20);
            this.percentField.TabIndex = 3;
            // 
            // priorField
            // 
            this.priorField.Location = new System.Drawing.Point(134, 215);
            this.priorField.Name = "priorField";
            this.priorField.Size = new System.Drawing.Size(209, 20);
            this.priorField.TabIndex = 4;
            // 
            // dataPicker
            // 
            this.dataPicker.Location = new System.Drawing.Point(134, 137);
            this.dataPicker.Name = "dataPicker";
            this.dataPicker.Size = new System.Drawing.Size(209, 20);
            this.dataPicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Percentual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prioridade(0,1,2):";
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(146, 293);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Cadastrar";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddButton_MouseClick_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(86, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 93);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // InserirTarefaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 341);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataPicker);
            this.Controls.Add(this.priorField);
            this.Controls.Add(this.percentField);
            this.Controls.Add(this.tiruloField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InserirTarefaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir Tarefa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InserirTarefaForm_FormClosed);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InserirTarefaForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tiruloField;
        private System.Windows.Forms.TextBox percentField;
        private System.Windows.Forms.TextBox priorField;
        private System.Windows.Forms.DateTimePicker dataPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}