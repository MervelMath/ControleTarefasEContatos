
namespace eAgenda.WindowsFormsApp.CompromissosModule
{
    partial class ExcluirCompromissoForm
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
            this.compromissoCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // excButton
            // 
            this.excButton.Location = new System.Drawing.Point(129, 157);
            this.excButton.Name = "excButton";
            this.excButton.Size = new System.Drawing.Size(75, 23);
            this.excButton.TabIndex = 6;
            this.excButton.Text = "Excluir";
            this.excButton.UseVisualStyleBackColor = true;
            this.excButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // compromissoCBox
            // 
            this.compromissoCBox.FormattingEnabled = true;
            this.compromissoCBox.Location = new System.Drawing.Point(48, 111);
            this.compromissoCBox.Name = "compromissoCBox";
            this.compromissoCBox.Size = new System.Drawing.Size(229, 21);
            this.compromissoCBox.TabIndex = 5;
            // 
            // ExcluirCompromissoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 231);
            this.Controls.Add(this.excButton);
            this.Controls.Add(this.compromissoCBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExcluirCompromissoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcluirCompromissoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExcluirCompromissoForm_FormClosed);
            this.Load += new System.EventHandler(this.ExcluirCompromissoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button excButton;
        private System.Windows.Forms.ComboBox compromissoCBox;
    }
}