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
    public partial class InserirCompromissoForm : Form
    {
        ControladorCompromissos controlador;
        ControladorCartoesContatos controladorContatos;
        PrincipalForm principalForm;

        public InserirCompromissoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCompromissos();
            controladorContatos = new ControladorCartoesContatos();
            Eventos();
            this.principalForm = principalForm;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            CartoesDeContatos contato = null;
            int idcontato = 0;

            if (contatoCBox.SelectedItem is CartoesDeContatos) 
            {
                contato = (CartoesDeContatos)contatoCBox.SelectedItem;
                idcontato = contato.id;
            }
            Compromisso compromisso = new Compromisso(assuntoField.Text, localField.Text, dateInPicker.Value, dateFimPicker.Value, linkField.Text, idcontato);
            string resultadoValidacao = controlador.VerificarInsercao(compromisso);

            if (resultadoValidacao == "VALIDA")
                MessageBox.Show("Contato Cadastrado!");

            else
                MessageBox.Show(resultadoValidacao);
        }

        private void InserirCompromissoForm_Load(object sender, EventArgs e)
        {
            CarregarComboBoxContatos();
        }

        private void CarregarComboBoxContatos()
        {
            contatoCBox.ResetText();
            contatoCBox.Items.Clear();
            contatoCBox.Items.Add("Nenhum");
            foreach (CartoesDeContatos contato in controladorContatos.SelecionarTodosRegistros())
            {
                contatoCBox.Items.Add(contato);
            }
        }

        private void InserirCompromissoForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void InserirCompromissoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
