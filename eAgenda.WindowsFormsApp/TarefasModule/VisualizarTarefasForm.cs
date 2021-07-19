using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace eAgenda.WindowsFormsApp
{
    public partial class VisualizarTarefasForm : Form
    {
        ControladorTarefa controlador;
        PrincipalForm principalForm;
        public VisualizarTarefasForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorTarefa();
            this.principalForm = principalForm;
        }

        private void VisualizarTarefasForm_Load(object sender, EventArgs e)
        {
            CarregarTabelaTarefas();
        }

        private void CarregarTabelaTarefas()
        {
            dataTable1.Clear();
            List<Tarefa> tarefas = controlador.SelecionarTodosRegistros();

            if (tdsRadio.Checked)
            {
                foreach (Tarefa tarefa in tarefas)
                {
                    var linha = dataTable1.NewRow();
                    AdicionarColunas(tarefa, ref linha);

                    dataTable1.Rows.Add(linha);
                }
            }
            if (cmpRadio.Checked)
            {
                foreach (Tarefa tarefa in tarefas)
                {
                    if (tarefa.percentual == "100" && tarefa.percentual == "100%")
                    {
                        var linha = dataTable1.NewRow();
                        AdicionarColunas(tarefa, ref linha);
                        dataTable1.Rows.Add(linha);
                    }
                }
            }

            if (pendRadio.Checked)
            {
                foreach (Tarefa tarefa in tarefas)
                {
                    if (tarefa.percentual != "100" && tarefa.percentual != "100%")
                    {
                        var linha = dataTable1.NewRow();
                        AdicionarColunas(tarefa, ref linha);
                        dataTable1.Rows.Add(linha);
                    }
                }
            }
        }

        private static void AdicionarColunas(Tarefa tarefa, ref DataRow linha)
        {
            linha["Id"] = tarefa.id;
            linha["Titulo"] = tarefa.titulo;
            linha["Data de Criacao"] = tarefa.dataCriacao;
            linha["Data de Conclusao"] = tarefa.dataConclusao;
            linha["Prioridade"] = tarefa.prioridade;
            linha["Porcentual"] = tarefa.percentual;
        }

        //string GetWeatherDisplay(double tempInCelsius)
        //=> tempInCelsius < 20.0 ? "Cold." : "Perfect!";
        private void cmpRadio_MouseClick(object sender, MouseEventArgs e)
        {
            CarregarTabelaTarefas();
            tdsRadio.Checked = false;
            pendRadio.Checked = false;
        }

        private void tdsRadio_MouseClick(object sender, MouseEventArgs e)
        {
            CarregarTabelaTarefas();
            cmpRadio.Checked = false;
            pendRadio.Checked = false;
        }

        private void pendRadio_MouseClick(object sender, MouseEventArgs e)
        {
            CarregarTabelaTarefas();
            cmpRadio.Checked = false;
            tdsRadio.Checked = false;
        }

        private void VisualizarTarefasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
