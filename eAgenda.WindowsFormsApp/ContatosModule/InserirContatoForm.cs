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
    public partial class InserirContatoForm : Form
    {
        ControladorCartoesContatos controlador;
        PrincipalForm principalForm;

        public InserirContatoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCartoesContatos();
            Eventos();
            this.principalForm = principalForm;
        }

        private void AddButton_MouseClick(object sender, MouseEventArgs e)
        {
            CartoesDeContatos contato = new CartoesDeContatos(nomeField.Text, emailField.Text, int.Parse(telefoneField.Text), empresaField.Text, cargoField.Text);
            string resultadoValidacao = controlador.VerificarInsercao(contato);

            if (resultadoValidacao == "VALIDA")
                MessageBox.Show("Contato Cadastrado!");

            else
                MessageBox.Show(resultadoValidacao);
        }

        private void InserirContatoForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void InserirContatoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
