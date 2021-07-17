
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp.ContatosModule
{
    partial class EditarContatoForm
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
            comboBox1.Leave += new EventHandler(CampoSaiu);
            telefoneField.Leave += new EventHandler(CampoSaiu);
            nomeField.Leave += new EventHandler(CampoSaiu);
            emailField.Leave += new EventHandler(CampoSaiu);
            empresaField.Leave += new EventHandler(CampoSaiu);
            cargoField.Leave += new EventHandler(CampoSaiu);
        }

        public void CampoSaiu(object sender, EventArgs e)
        {
            if (sender is Control txt) //MaskedTextBox, TextBox
            {
                if (txt.Text.Length == 0)
                {
                    txt.BackColor = Color.LightCoral;
                    EditarButton.Enabled = false;
                    txt.TabStop = true;
                }
                else
                {
                    txt.TabStop = false;
                    txt.BackColor = Color.Green;
                    EditarButton.Enabled = VerificarCamposNulos();
                }
            }

        }

        private bool VerificarCamposNulos()
        {
            if (comboBox1.Text.EhVazia() || telefoneField.Text.EhVazia() || nomeField.Text.EhVazia() || emailField.Text.EhVazia() || empresaField.Text.EhVazia() || cargoField.Text.EhVazia())
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
            this.label5 = new System.Windows.Forms.Label();
            this.cargoField = new System.Windows.Forms.TextBox();
            this.emailField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.empresaField = new System.Windows.Forms.TextBox();
            this.telefoneField = new System.Windows.Forms.TextBox();
            this.nomeField = new System.Windows.Forms.TextBox();
            this.EditarButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Cargo:";
            // 
            // cargoField
            // 
            this.cargoField.Location = new System.Drawing.Point(121, 272);
            this.cargoField.Name = "cargoField";
            this.cargoField.Size = new System.Drawing.Size(209, 20);
            this.cargoField.TabIndex = 6;
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(121, 156);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(209, 20);
            this.emailField.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Telefone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nome:";
            // 
            // empresaField
            // 
            this.empresaField.Location = new System.Drawing.Point(121, 234);
            this.empresaField.Name = "empresaField";
            this.empresaField.Size = new System.Drawing.Size(209, 20);
            this.empresaField.TabIndex = 5;
            // 
            // telefoneField
            // 
            this.telefoneField.Location = new System.Drawing.Point(121, 195);
            this.telefoneField.Name = "telefoneField";
            this.telefoneField.Size = new System.Drawing.Size(209, 20);
            this.telefoneField.TabIndex = 4;
            // 
            // nomeField
            // 
            this.nomeField.Location = new System.Drawing.Point(121, 118);
            this.nomeField.Name = "nomeField";
            this.nomeField.Size = new System.Drawing.Size(209, 20);
            this.nomeField.TabIndex = 2;
            // 
            // EditarButton
            // 
            this.EditarButton.Location = new System.Drawing.Point(156, 334);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(75, 23);
            this.EditarButton.TabIndex = 32;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = true;
            this.EditarButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditarButton_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // EditarContatoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 389);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cargoField);
            this.Controls.Add(this.emailField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.empresaField);
            this.Controls.Add(this.telefoneField);
            this.Controls.Add(this.nomeField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditarContatoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarContatoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditarContatoForm_FormClosed);
            this.Load += new System.EventHandler(this.EditarContatoForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditarContatoForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cargoField;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox empresaField;
        private System.Windows.Forms.TextBox telefoneField;
        private System.Windows.Forms.TextBox nomeField;
        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}