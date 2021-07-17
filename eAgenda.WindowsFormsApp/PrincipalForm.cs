using eAgenda.WindowsFormsApp.CompromissosModule;
using eAgenda.WindowsFormsApp.ContatosModule;
using System.Windows.Forms;

namespace eAgenda.WindowsFormsApp
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Tarefas");
            comboBox1.Items.Add("Contatos");
            comboBox1.Items.Add("Compromissos");
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Tarefas":
                    CriarExibirTela(new InserirTarefaForm(this));
                    break;

                case "Contatos":
                    CriarExibirTela(new InserirContatoForm(this));
                    break;

                case "Compromissos":
                    CriarExibirTela(new InserirCompromissoForm(this));
                    break;
            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Tarefas":
                    CriarExibirTela(new VisualizarTarefasForm(this));
                    break;

                case "Contatos":
                    CriarExibirTela(new VisualizarContatosForm(this));
                    break;

                case "Compromissos":
                    CriarExibirTela(new VisualizarCompromissosForm(this));
                    break;
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Tarefas":
                    CriarExibirTela(new EditarTarefaForm(this));
                    break;
                
                case "Contatos":
                    CriarExibirTela(new EditarContatoForm(this));
                    break;

                case "Compromissos":
                    CriarExibirTela(new EditarCompromissoForm(this));
                    break;
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Tarefas":
                    CriarExibirTela(new ExcluirTarefaForm(this));
                    break;

                case "Contatos":
                    CriarExibirTela(new ExcluirContatoForm(this));
                    break;

                case "Compromissos":
                    CriarExibirTela(new ExcluirCompromissoForm(this));
                    break;
            }
        }

        private void CriarExibirTela(Form tela)
        {
            tela.Visible = true;
            Hide();
        }
    }
}
