
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp
{
    partial class EditarTarefaForm
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
            tarefaCBox.Leave += new EventHandler(CampoSaiu);
            tituloField.Leave += new EventHandler(CampoSaiu);
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
                    editarButton.Enabled = false;
                }
                else
                {
                    txt.TabStop = false;
                    txt.BackColor = Color.Green;
                    editarButton.Enabled = VerificarCamposNulos();
                }
            }

        }

        private bool VerificarCamposNulos()
        {
            if (tituloField.Text.EhVazia() || dataPicker.Text.EhVazia() || percentField.Text.EhVazia() || priorField.Text.EhVazia())
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarTarefaForm));
            this.tarefaCBox = new System.Windows.Forms.ComboBox();
            this.editarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataPicker = new System.Windows.Forms.DateTimePicker();
            this.priorField = new System.Windows.Forms.TextBox();
            this.percentField = new System.Windows.Forms.TextBox();
            this.tituloField = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tarefaCBox
            // 
            this.tarefaCBox.FormattingEnabled = true;
            this.tarefaCBox.Location = new System.Drawing.Point(44, 99);
            this.tarefaCBox.Name = "tarefaCBox";
            this.tarefaCBox.Size = new System.Drawing.Size(229, 21);
            this.tarefaCBox.TabIndex = 1;
            // 
            // editarButton
            // 
            this.editarButton.Location = new System.Drawing.Point(132, 320);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(75, 23);
            this.editarButton.TabIndex = 10;
            this.editarButton.Text = "Editar";
            this.editarButton.UseVisualStyleBackColor = true;
            this.editarButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editarButton_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Prioridade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Percentual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Título:";
            // 
            // dataPicker
            // 
            this.dataPicker.Location = new System.Drawing.Point(115, 192);
            this.dataPicker.Name = "dataPicker";
            this.dataPicker.Size = new System.Drawing.Size(209, 20);
            this.dataPicker.TabIndex = 3;
            // 
            // priorField
            // 
            this.priorField.Location = new System.Drawing.Point(115, 270);
            this.priorField.Name = "priorField";
            this.priorField.Size = new System.Drawing.Size(209, 20);
            this.priorField.TabIndex = 5;
            // 
            // percentField
            // 
            this.percentField.Location = new System.Drawing.Point(115, 231);
            this.percentField.Name = "percentField";
            this.percentField.Size = new System.Drawing.Size(209, 20);
            this.percentField.TabIndex = 4;
            // 
            // tituloField
            // 
            this.tituloField.Location = new System.Drawing.Point(115, 154);
            this.tituloField.Name = "tituloField";
            this.tituloField.Size = new System.Drawing.Size(209, 20);
            this.tituloField.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 93);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // EditarTarefaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataPicker);
            this.Controls.Add(this.priorField);
            this.Controls.Add(this.percentField);
            this.Controls.Add(this.tituloField);
            this.Controls.Add(this.editarButton);
            this.Controls.Add(this.tarefaCBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditarTarefaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarTarefaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditarTarefaForm_FormClosed);
            this.Load += new System.EventHandler(this.EditarTarefaForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditarTarefaForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tarefaCBox;
        private System.Windows.Forms.Button editarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dataPicker;
        private System.Windows.Forms.TextBox priorField;
        private System.Windows.Forms.TextBox percentField;
        private System.Windows.Forms.TextBox tituloField;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}