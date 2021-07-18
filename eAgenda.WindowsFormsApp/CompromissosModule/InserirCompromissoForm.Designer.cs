
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp.CompromissosModule
{
    partial class InserirCompromissoForm
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
            contatoCBox.Leave += new EventHandler(CampoSaiu);
            assuntoField.Leave += new EventHandler(CampoSaiu);
            localField.Leave += new EventHandler(CampoSaiu);
            dateInPicker.Leave += new EventHandler(CampoSaiu);
            dateFimPicker.Leave += new EventHandler(CampoSaiu);
            linkField.Leave += new EventHandler(CampoSaiu);
        }

        public void CampoSaiu(object sender, EventArgs e)
        {
            if (sender is Control txt) //MaskedTextBox, TextBox
            {
                if (txt.Text.Length == 0)
                {
                    txt.TabStop = true;
                    txt.BackColor = Color.LightCoral;
                    addButton.Enabled = false;
                }
                else
                {
                    txt.TabStop = false;
                    txt.BackColor = Color.Green;
                    addButton.Enabled = VerificarCamposNulos();
                }
            }

        }

        private bool VerificarCamposNulos()
        {
            if (contatoCBox.Text.EhVazia() || assuntoField.Text.EhVazia() || localField.Text.EhVazia() || dateInPicker.Text.EhVazia() || dateFimPicker.Text.EhVazia() || linkField.Text.EhVazia())
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InserirCompromissoForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateInPicker = new System.Windows.Forms.DateTimePicker();
            this.localField = new System.Windows.Forms.TextBox();
            this.linkField = new System.Windows.Forms.TextBox();
            this.assuntoField = new System.Windows.Forms.TextBox();
            this.dateFimPicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.contatoCBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Local:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Data de Término:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data de Início:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Assunto:";
            // 
            // dateInPicker
            // 
            this.dateInPicker.Location = new System.Drawing.Point(170, 236);
            this.dateInPicker.Name = "dateInPicker";
            this.dateInPicker.Size = new System.Drawing.Size(209, 20);
            this.dateInPicker.TabIndex = 4;
            // 
            // localField
            // 
            this.localField.Location = new System.Drawing.Point(170, 194);
            this.localField.Name = "localField";
            this.localField.Size = new System.Drawing.Size(209, 20);
            this.localField.TabIndex = 3;
            // 
            // linkField
            // 
            this.linkField.Location = new System.Drawing.Point(170, 309);
            this.linkField.Name = "linkField";
            this.linkField.Size = new System.Drawing.Size(209, 20);
            this.linkField.TabIndex = 6;
            // 
            // assuntoField
            // 
            this.assuntoField.Location = new System.Drawing.Point(170, 150);
            this.assuntoField.Name = "assuntoField";
            this.assuntoField.Size = new System.Drawing.Size(209, 20);
            this.assuntoField.TabIndex = 2;
            // 
            // dateFimPicker
            // 
            this.dateFimPicker.Location = new System.Drawing.Point(170, 271);
            this.dateFimPicker.Name = "dateFimPicker";
            this.dateFimPicker.Size = new System.Drawing.Size(209, 20);
            this.dateFimPicker.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Link:";
            // 
            // contatoCBox
            // 
            this.contatoCBox.FormattingEnabled = true;
            this.contatoCBox.Location = new System.Drawing.Point(170, 77);
            this.contatoCBox.Name = "contatoCBox";
            this.contatoCBox.Size = new System.Drawing.Size(121, 21);
            this.contatoCBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Contato (opcional):";
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(177, 347);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Inserir";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(71, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 69);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // InserirCompromissoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 382);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contatoCBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateFimPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateInPicker);
            this.Controls.Add(this.localField);
            this.Controls.Add(this.linkField);
            this.Controls.Add(this.assuntoField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InserirCompromissoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InserirCompromissoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InserirCompromissoForm_FormClosed);
            this.Load += new System.EventHandler(this.InserirCompromissoForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InserirCompromissoForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateInPicker;
        private System.Windows.Forms.TextBox localField;
        private System.Windows.Forms.TextBox linkField;
        private System.Windows.Forms.TextBox assuntoField;
        private System.Windows.Forms.DateTimePicker dateFimPicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox contatoCBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addButton;
        private PictureBox pictureBox1;
    }
}