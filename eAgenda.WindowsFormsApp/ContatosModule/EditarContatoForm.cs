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
    public partial class EditarContatoForm : Form
    {
        ControladorCartoesContatos controlador;
        PrincipalForm principalForm;

        public EditarContatoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCartoesContatos();
            Eventos();
            this.principalForm = principalForm;
        }

        private void EditarContatoForm_Load(object sender, EventArgs e)
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

        private void EditarButton_MouseClick(object sender, MouseEventArgs e)
        {
            CartoesDeContatos contato = new CartoesDeContatos(nomeField.Text, emailField.Text, int.Parse(telefoneField.Text), empresaField.Text, cargoField.Text);

            CartoesDeContatos contatoTest = (CartoesDeContatos)comboBox1.SelectedItem;
            contato.id = contatoTest.id;
            string resultadoValidacao = controlador.VerificarInsercao(contato);

            if (resultadoValidacao == "VALIDA")
                MessageBox.Show("Sucesso!");

            else
                MessageBox.Show(resultadoValidacao);

            CriarComboBoxContatos();
        }

        private void EditarContatoForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void EditarContatoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
