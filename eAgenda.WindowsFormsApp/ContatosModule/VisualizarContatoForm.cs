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
    public partial class VisualizarContatosForm : Form
    {
        ControladorCartoesContatos controlador;
        PrincipalForm principalForm;
        public VisualizarContatosForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCartoesContatos();
            this.principalForm = principalForm;
        }

        private void VisualizarContatoForm_Load(object sender, EventArgs e)
        {
            CarregarTabelaContatos();
        }

        private void CarregarTabelaContatos()
        {
            dtContatos.Clear();
            List<CartoesDeContatos> contatos = controlador.SelecionarTodosRegistros();

            foreach (CartoesDeContatos contato in contatos)
            {
                var linha = dtContatos.NewRow();
                AdicionarColunas(contato, ref linha);

                dtContatos.Rows.Add(linha);
            }
        }

        private static void AdicionarColunas(CartoesDeContatos contato, ref DataRow linha)
        {
            linha["Id"] = contato.id;
            linha["Nome"] = contato.nome;
            linha["Email"] = contato.email;
            linha["Telefone"] = contato.telefone;
            linha["Empresa"] = contato.empresa;
            linha["Cargo"] = contato.cargo;
        }

        private void VisualizarContatosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
