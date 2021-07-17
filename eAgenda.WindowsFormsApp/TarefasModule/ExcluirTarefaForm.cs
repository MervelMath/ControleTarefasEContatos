using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp
{
    public partial class ExcluirTarefaForm : Form
    {
        ControladorTarefa controlador;
        PrincipalForm principalForm;

        public ExcluirTarefaForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorTarefa();
            this.principalForm = principalForm;
        }

        private void ExcluirTarefaForm_Load(object sender, EventArgs e)
        {
            CriarComboBoxTarefas();
        }

        private void CriarComboBoxTarefas()
        {
            tarefaCBox.ResetText();
            tarefaCBox.Items.Clear();
            foreach (Tarefa tarefa in controlador.SelecionarTodosRegistros())
            {
                tarefaCBox.Items.Add(tarefa);
            }
        }

        private void excluirButton_MouseClick(object sender, MouseEventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que quer excluir a tarefa?",
                                     "Confirme a Exclusão!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Tarefa tarefa = (Tarefa)tarefaCBox.SelectedItem;
                bool conseguiuExcluir = controlador.VerificarExclusao(tarefa.id);
                if (conseguiuExcluir)
                    MessageBox.Show("Sucesso!");

                else
                    MessageBox.Show("Falha ao tentar excluir!");

                CriarComboBoxTarefas();
            }
            
        }

        private void ExcluirTarefaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
