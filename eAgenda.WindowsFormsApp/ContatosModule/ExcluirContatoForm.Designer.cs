
namespace eAgenda.WindowsFormsApp.ContatosModule
{
    partial class ExcluirContatoForm
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
            this.excButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // excButton
            // 
            this.excButton.Location = new System.Drawing.Point(128, 149);
            this.excButton.Name = "excButton";
            this.excButton.Size = new System.Drawing.Size(75, 23);
            this.excButton.TabIndex = 4;
            this.excButton.Text = "Excluir";
            this.excButton.UseVisualStyleBackColor = true;
            this.excButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExcButton_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(47, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // ExcluirContatoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 207);
            this.Controls.Add(this.excButton);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExcluirContatoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcluirContatoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExcluirContatoForm_FormClosed);
            this.Load += new System.EventHandler(this.ExcluirContatoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button excButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}