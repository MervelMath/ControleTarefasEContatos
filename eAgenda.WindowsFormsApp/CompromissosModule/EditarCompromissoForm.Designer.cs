
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp.CompromissosModule
{
    partial class EditarCompromissoForm
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
            compromissoCBox.Leave += new EventHandler(CampoSaiu);
            contatosCBox.Leave += new EventHandler(CampoSaiu);
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
            if (contatosCBox.Text.EhVazia() || compromissoCBox.Text.EhVazia() || assuntoField.Text.EhVazia() || localField.Text.EhVazia() || dateInPicker.Text.EhVazia() || dateFimPicker.Text.EhVazia() || linkField.Text.EhVazia())
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
            this.editarButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.contatosCBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateFimPicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateInPicker = new System.Windows.Forms.DateTimePicker();
            this.localField = new System.Windows.Forms.TextBox();
            this.linkField = new System.Windows.Forms.TextBox();
            this.assuntoField = new System.Windows.Forms.TextBox();
            this.compromissoCBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editarButton
            // 
            this.editarButton.Enabled = false;
            this.editarButton.Location = new System.Drawing.Point(177, 386);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(75, 23);
            this.editarButton.TabIndex = 34;
            this.editarButton.Text = "Editar";
            this.editarButton.UseVisualStyleBackColor = true;
            this.editarButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditarButton_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Contato (opcional):";
            // 
            // contatosCBox
            // 
            this.contatosCBox.FormattingEnabled = true;
            this.contatosCBox.Location = new System.Drawing.Point(177, 129);
            this.contatosCBox.Name = "contatosCBox";
            this.contatosCBox.Size = new System.Drawing.Size(121, 21);
            this.contatosCBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Link:";
            // 
            // dateFimPicker
            // 
            this.dateFimPicker.Location = new System.Drawing.Point(177, 303);
            this.dateFimPicker.Name = "dateFimPicker";
            this.dateFimPicker.Size = new System.Drawing.Size(209, 20);
            this.dateFimPicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Local:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Data de Término:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Data de Início:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Assunto:";
            // 
            // dateInPicker
            // 
            this.dateInPicker.Location = new System.Drawing.Point(177, 268);
            this.dateInPicker.Name = "dateInPicker";
            this.dateInPicker.Size = new System.Drawing.Size(209, 20);
            this.dateInPicker.TabIndex = 5;
            // 
            // localField
            // 
            this.localField.Location = new System.Drawing.Point(177, 226);
            this.localField.Name = "localField";
            this.localField.Size = new System.Drawing.Size(209, 20);
            this.localField.TabIndex = 4;
            // 
            // linkField
            // 
            this.linkField.Location = new System.Drawing.Point(177, 341);
            this.linkField.Name = "linkField";
            this.linkField.Size = new System.Drawing.Size(209, 20);
            this.linkField.TabIndex = 7;
            // 
            // assuntoField
            // 
            this.assuntoField.Location = new System.Drawing.Point(177, 182);
            this.assuntoField.Name = "assuntoField";
            this.assuntoField.Size = new System.Drawing.Size(209, 20);
            this.assuntoField.TabIndex = 3;
            // 
            // compromissoCBox
            // 
            this.compromissoCBox.FormattingEnabled = true;
            this.compromissoCBox.Location = new System.Drawing.Point(177, 83);
            this.compromissoCBox.Name = "compromissoCBox";
            this.compromissoCBox.Size = new System.Drawing.Size(166, 21);
            this.compromissoCBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Compromisso:";
            // 
            // EditarCompromissoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 424);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.compromissoCBox);
            this.Controls.Add(this.editarButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contatosCBox);
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
            this.Name = "EditarCompromissoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarCompromissoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditarCompromissoForm_FormClosed);
            this.Load += new System.EventHandler(this.EditarCompromissoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editarButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox contatosCBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateFimPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateInPicker;
        private System.Windows.Forms.TextBox localField;
        private System.Windows.Forms.TextBox linkField;
        private System.Windows.Forms.TextBox assuntoField;
        private System.Windows.Forms.ComboBox compromissoCBox;
        private System.Windows.Forms.Label label7;
    }
}