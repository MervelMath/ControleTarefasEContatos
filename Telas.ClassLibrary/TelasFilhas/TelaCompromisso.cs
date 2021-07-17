using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telas.ClassLibrary.TelasMae;

namespace Telas.ClassLibrary
{
    public class TelaCompromisso : TelaCadastroBasico<Compromisso>, ICadastravel
    {

        public TelaCompromisso(ControladorBase<Compromisso> controlador) : base(controlador,
            "Tela de Compromissos", "compromisso")
        { }

        public override void MontarTabela(List<Compromisso> compromissos)
        {
            string configuracaoColunasTabela = "{0,-7} | {1,-20} | {2,-20} | {3, -25} | {4, -15} | {5, -10} | {6, -15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Assunto", "Local",
                "Data Início", "Data Término", "Link da Reunião", "Nome");

            compromissos = OrganizarEExibirCompromissos(compromissos, configuracaoColunasTabela);
        }

        private static List<Compromisso> OrganizarEExibirCompromissos(List<Compromisso> compromissos, string configuracaoColunasTabela)
        {
            compromissos = compromissos.OrderByDescending(x => x.DataInicio).ThenByDescending(x => x.DataInicio.TimeOfDay).ToList();

            Console.WriteLine("");
            Console.WriteLine("Compromissos ainda não concluídos: ");
            Console.WriteLine("...");
            Console.WriteLine("");

            foreach (Compromisso compromisso in compromissos)
            {
                if (DataDeInicioEhMaiorQueADataAtual(compromisso))
                    Console.WriteLine(configuracaoColunasTabela, compromisso.id, compromisso.Assunto, compromisso.Local,
                        compromisso.DataInicio, compromisso.DataTermino, compromisso.LinkReuniao, compromisso.nomeContato);
            }

            Console.WriteLine("");
            Console.WriteLine("Compromissos concluídos: ");
            Console.WriteLine("...");
            Console.WriteLine("");

            foreach (Compromisso compromisso in compromissos)
            {
                if (DataJaPassou(compromisso))
                    Console.WriteLine(configuracaoColunasTabela, compromisso.id, compromisso.Assunto, compromisso.Local,
                    compromisso.DataInicio, compromisso.DataTermino, compromisso.LinkReuniao, compromisso.nomeContato);
            }

            return compromissos;
        }

        public override Compromisso ObterRegistro()
        {
            List<int> listaIds = new List<int>();
            MostrarTodosOsContatos(ref listaIds);

            Console.Write("Digite o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do encontro: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data de início compromisso (use o formato (dd/mm/yyyy hh:mm): ");
            DateTime dataInicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a data para o término do compromisso: ");
            DateTime dataFim = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o link da reunião, caso ela seja online:  ");
            string linkReuniao = Console.ReadLine();

            int idContato = 0;
            idContato = VerificarEInserirIDCOntato(listaIds);

            Compromisso compromisso = new Compromisso(assunto, local, dataInicio, dataFim, linkReuniao, idContato);

            return compromisso;
        }
        private static bool DataJaPassou(Compromisso compromisso)
        {
            return DateTime.Compare(compromisso.DataInicio, DateTime.Now) < 0;
        }

        private static bool DataDeInicioEhMaiorQueADataAtual(Compromisso compromisso)
        {
            return DateTime.Compare(compromisso.DataInicio, DateTime.Now) >= 0;
        }

        private int VerificarEInserirIDCOntato(List<int> listaIds)
        {
            int idContato=0;
            do
            {
                Console.Write("Digite o id do contato para a reunião: ");
                try
                {
                    idContato = Convert.ToInt32(Console.ReadLine());
                    if (listaIds.Contains(idContato))
                        break;
                }
                catch (Exception)
                {
                    idContato = 0;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID do contato inválido!");
                Console.WriteLine("");
                Console.ResetColor();

            } while (!listaIds.Contains(idContato));
            return idContato;
        }
        private static void MostrarTodosOsContatos(ref List<int> listaIds)
        {
            ControladorCartoesContatos controladorCartoes = new ControladorCartoesContatos();
            Console.WriteLine("Contatos disponíveis: ");
            foreach (CartoesDeContatos contato in controladorCartoes.SelecionarTodosRegistros())
            {
                Console.WriteLine("           ");
                Console.WriteLine(contato.nome + " - ID: " + contato.id);
                listaIds.Add(contato.id);
            }
            Console.WriteLine("");
        }
    }
}
