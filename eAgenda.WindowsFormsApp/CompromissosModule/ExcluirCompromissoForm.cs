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

namespace eAgenda.WindowsFormsApp.CompromissosModule
{
    public partial class ExcluirCompromissoForm : Form
    {
        ControladorCompromissos controlador;
        PrincipalForm principalForm;

        public ExcluirCompromissoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCompromissos();
            this.principalForm = principalForm;
        }

        private void ExcluirCompromissoForm_Load(object sender, EventArgs e)
        {
            CarregarComboBoxCompromissos();
        }

        private void CarregarComboBoxCompromissos()
        {
            compromissoCBox.ResetText();
            compromissoCBox.Items.Clear();
            foreach (Compromisso compromisso in controlador.SelecionarTodosRegistros())
            {
                compromissoCBox.Items.Add(compromisso);
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que quer excluir a tarefa?",
                                     "Confirme a Exclusão!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Compromisso compromisso = (Compromisso)compromissoCBox.SelectedItem;

                bool conseguiuExcluir = controlador.VerificarExclusao(compromisso.id);

                if (conseguiuExcluir)
                    MessageBox.Show("Sucesso!");

                else
                    MessageBox.Show("Falha ao tentar excluir!");

                CarregarComboBoxCompromissos();
            }
        }

        private void ExcluirCompromissoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
