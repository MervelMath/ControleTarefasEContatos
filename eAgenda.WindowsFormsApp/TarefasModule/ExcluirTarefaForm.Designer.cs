
namespace eAgenda.WindowsFormsApp
{
    partial class ExcluirTarefaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcluirTarefaForm));
            this.tarefaCBox = new System.Windows.Forms.ComboBox();
            this.excluirButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tarefaCBox
            // 
            this.tarefaCBox.FormattingEnabled = true;
            this.tarefaCBox.Location = new System.Drawing.Point(49, 89);
            this.tarefaCBox.Name = "tarefaCBox";
            this.tarefaCBox.Size = new System.Drawing.Size(229, 21);
            this.tarefaCBox.TabIndex = 1;
            // 
            // excluirButton
            // 
            this.excluirButton.Location = new System.Drawing.Point(130, 135);
            this.excluirButton.Name = "excluirButton";
            this.excluirButton.Size = new System.Drawing.Size(75, 23);
            this.excluirButton.TabIndex = 2;
            this.excluirButton.Text = "Excluir";
            this.excluirButton.UseVisualStyleBackColor = true;
            this.excluirButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.excluirButton_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, -19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 93);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ExcluirTarefaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 170);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.excluirButton);
            this.Controls.Add(this.tarefaCBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExcluirTarefaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcluirTarefaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExcluirTarefaForm_FormClosed);
            this.Load += new System.EventHandler(this.ExcluirTarefaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox tarefaCBox;
        private System.Windows.Forms.Button excluirButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}