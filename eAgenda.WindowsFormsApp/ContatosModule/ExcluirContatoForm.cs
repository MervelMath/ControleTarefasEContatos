using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp.ContatosModule
{
    public partial class ExcluirContatoForm : Form
    {
        ControladorCartoesContatos controlador;
        PrincipalForm principalForm;

        public ExcluirContatoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCartoesContatos();
            this.principalForm = principalForm;
        }

        private void ExcluirContatoForm_Load(object sender, EventArgs e)
        {
            CriarComboBoxContatos();
        }

        private void CriarComboBoxContatos()
        {
            comboBox1.ResetText();
            comboBox1.Items.Clear();
            foreach (CartoesDeContatos contato in controlador.SelecionarTodosRegistros())
            {
                comboBox1.Items.Add(contato);
            }
        }

        private void ExcButton_MouseClick(object sender, MouseEventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que quer excluir a tarefa?",
                                     "Confirme a Exclusão!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                CartoesDeContatos contato = (CartoesDeContatos)comboBox1.SelectedItem;

                bool conseguiuExcluir = controlador.VerificarExclusao(contato.id);

                if (conseguiuExcluir)
                    MessageBox.Show("Sucesso!");

                else
                    MessageBox.Show("Falha ao tentar excluir!");

                CriarComboBoxContatos();
            }
        }

        private void ExcluirContatoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
