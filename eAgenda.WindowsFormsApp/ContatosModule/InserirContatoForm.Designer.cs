
using System;
using System.Drawing;
using System.Windows.Forms;
using eAgenda.WindowsFormsApp;

namespace eAgenda.WindowsFormsApp.ContatosModule
{
    partial class InserirContatoForm
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
            if (telefoneField.Text.EhVazia() || nomeField.Text.EhVazia() || emailField.Text.EhVazia() || empresaField.Text.EhVazia() || cargoField.Text.EhVazia())
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
            this.addButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.empresaField = new System.Windows.Forms.TextBox();
            this.nomeField = new System.Windows.Forms.TextBox();
            this.emailField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cargoField = new System.Windows.Forms.TextBox();
            this.telefoneField = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(150, 317);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 18;
            this.addButton.Text = "Cadastrar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddButton_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Telefone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nome:";
            // 
            // empresaField
            // 
            this.empresaField.Location = new System.Drawing.Point(117, 202);
            this.empresaField.Name = "empresaField";
            this.empresaField.Size = new System.Drawing.Size(209, 20);
            this.empresaField.TabIndex = 4;
            // 
            // nomeField
            // 
            this.nomeField.Location = new System.Drawing.Point(117, 86);
            this.nomeField.Name = "nomeField";
            this.nomeField.Size = new System.Drawing.Size(209, 20);
            this.nomeField.TabIndex = 1;
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(117, 124);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(209, 20);
            this.emailField.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cargo:";
            // 
            // cargoField
            // 
            this.cargoField.Location = new System.Drawing.Point(117, 240);
            this.cargoField.Name = "cargoField";
            this.cargoField.Size = new System.Drawing.Size(209, 20);
            this.cargoField.TabIndex = 5;
            // 
            // telefoneField
            // 
            this.telefoneField.Location = new System.Drawing.Point(117, 163);
            this.telefoneField.Mask = "900000000";
            this.telefoneField.Name = "telefoneField";
            this.telefoneField.Size = new System.Drawing.Size(209, 20);
            this.telefoneField.TabIndex = 3;
            // 
            // InserirContatoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 372);
            this.Controls.Add(this.telefoneField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cargoField);
            this.Controls.Add(this.emailField);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.empresaField);
            this.Controls.Add(this.nomeField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InserirContatoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InserirContatoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InserirContatoForm_FormClosed);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InserirContatoForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox empresaField;
        private System.Windows.Forms.TextBox nomeField;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cargoField;
        private System.Windows.Forms.MaskedTextBox telefoneField;
    }
}