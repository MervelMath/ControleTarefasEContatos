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
    public partial class EditarCompromissoForm : Form
    {
        ControladorCompromissos controlador;
        ControladorCartoesContatos controladorContato;
        PrincipalForm principalForm;

        public EditarCompromissoForm(PrincipalForm principalForm)
        {
            InitializeComponent();
            controlador = new ControladorCompromissos();
            controladorContato = new ControladorCartoesContatos();
            this.principalForm = principalForm;
            Eventos();
        }

        private void EditarCompromissoForm_Load(object sender, EventArgs e)
        {
            CriarComboBoxCompromisso();
            CriarComboBoxContato();
        }

        private void CriarComboBoxContato()
        {
            contatosCBox.ResetText();
            contatosCBox.Items.Clear();
            foreach (CartoesDeContatos contato in controladorContato.SelecionarTodosRegistros())
            {
                contatosCBox.Items.Add(contato);
            }
        }

        private void CriarComboBoxCompromisso()
        {
            compromissoCBox.ResetText();
            compromissoCBox.Items.Clear();
            foreach (Compromisso compromisso in controlador.SelecionarTodosRegistros())
            {
                compromissoCBox.Items.Add(compromisso);
            }
        }

        private void EditarButton_MouseClick(object sender, MouseEventArgs e)
        {
            CartoesDeContatos contato = null;
            int idcontato = 0;
                if (contatosCBox.SelectedItem is CartoesDeContatos)
                {
                    contato = (CartoesDeContatos)contatosCBox.SelectedItem;
                    idcontato = contato.id;
                }

                Compromisso compromisso = new Compromisso(assuntoField.Text, localField.Text, dateInPicker.Value, dateFimPicker.Value, linkField.Text, idcontato);
                Compromisso compromissoSelecionado = (Compromisso)compromissoCBox.SelectedItem;
                compromisso.id = compromissoSelecionado.id;

                string resultadoValidacao = controlador.VerificarInsercao(compromisso);

                if (resultadoValidacao == "VALIDA")
                    MessageBox.Show("Contato Cadastrado!");

                else
                    MessageBox.Show(resultadoValidacao);
            
        }

        private void EditarCompromissoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            principalForm.Show();
        }
    }
}
