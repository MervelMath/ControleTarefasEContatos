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
    public partial class VisualizarCompromissosForm : Form
    {
        ControladorCompromissos controlador;
        PrincipalForm principalForm;

        public VisualizarCompromissosForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCompromissos();
            this.principalForm = principalForm;
        }

        private void VisualizarCompromissosForm_Load(object sender, EventArgs e)
        {
            CarregarTabelaCompromissos();
        }

        private void CarregarTabelaCompromissos()
        {
            dTCompromissos.Clear();
            List<Compromisso> contatos = controlador.SelecionarTodosRegistros();

            foreach (Compromisso contato in contatos)
            {
                var linha = dTCompromissos.NewRow();
                CriarColunas(contato, ref linha);

                dTCompromissos.Rows.Add(linha);
            }
        }

        private static void CriarColunas(Compromisso contato, ref DataRow linha)
        {
            linha["Id"] = contato.id;
            linha["Assunto"] = contato.Assunto;
            linha["Local"] = contato.Local;
            linha["Data Inicio"] = contato.DataInicio;
            linha["Termino"] = contato.DataTermino;
            linha["Link"] = contato.LinkReuniao;
            linha["Contato"] = contato.nomeContato;
        }

        private void VisualizarCompromissosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
