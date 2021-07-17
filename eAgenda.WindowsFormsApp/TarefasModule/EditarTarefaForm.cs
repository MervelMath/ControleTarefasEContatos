using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp
{
    public partial class EditarTarefaForm : Form
    {
        ControladorTarefa controlador;
        PrincipalForm principalForm;

        public EditarTarefaForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorTarefa();
            Eventos();
            this.principalForm = principalForm;
        }

        private void EditarTarefaForm_Load(object sender, EventArgs e)
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

        private void editarButton_MouseClick(object sender, MouseEventArgs e)
        {
            Tarefa tarefa = new Tarefa(int.Parse(priorField.Text), tituloField.Text, DateTime.Now,
                dataPicker.Value, percentField.Text);

            Tarefa tarefaTest = (Tarefa)tarefaCBox.SelectedItem;
            tarefa.id = tarefaTest.id;
            string resultadoValidacao = controlador.VerificarInsercao(tarefa);

            if (resultadoValidacao == "VALIDA")
                MessageBox.Show("Sucesso!");

            else
                MessageBox.Show(resultadoValidacao);

            CriarComboBoxTarefas();
        }

        private void EditarTarefaForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void EditarTarefaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
