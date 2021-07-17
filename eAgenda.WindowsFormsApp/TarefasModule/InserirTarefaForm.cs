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

namespace eAgenda.WindowsFormsApp
{
    public partial class InserirTarefaForm : Form
    {
        ControladorTarefa controlador;
        PrincipalForm principalForm;

        public InserirTarefaForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            this.controlador = new ControladorTarefa();
            Eventos();
            this.principalForm = principalForm;
        }


        private void AddButton_MouseClick_1(object sender, MouseEventArgs e)
        {
            Tarefa tarefa = new Tarefa(int.Parse(priorField.Text), tiruloField.Text, DateTime.Now, dataPicker.Value, percentField.Text);
            string resultadoValidacao = controlador.VerificarInsercao(tarefa);

            if (resultadoValidacao == "VALIDA")
                MessageBox.Show("Tarefa Cadastrada!");

            else
                MessageBox.Show(resultadoValidacao);
        }

        private void InserirTarefaForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void InserirTarefaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
