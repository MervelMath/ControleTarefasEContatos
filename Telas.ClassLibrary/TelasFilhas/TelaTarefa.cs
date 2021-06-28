using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using Telas.ClassLibrary.TelasMae;

namespace Telas.ClassLibrary
{
    public class TelaTarefa : TelaCadastroBasico<Tarefa>, ICadastravel
    {

        public TelaTarefa(ControladorBase<Tarefa> controlador) : base(controlador, "Tela de Tarefas", "tarefa")
        {

        }



        public override void MontarTabela(List<Tarefa> tarefas)
        {

            string configuracaoColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3, -25} | {4, -10} | {5, -10}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Título", "Data de Criacao",
                "Data de Conclusao", "Percentual", "Prioridade");

            foreach (Tarefa tarefa in tarefas)
            {
                if(tarefa.percentual == "100%")
                Console.WriteLine(configuracaoColunasTabela, tarefa.id, tarefa.titulo, tarefa.dataCriacao,
                    tarefa.dataConclusao, tarefa.percentual, tarefa.prioridade);
            }

            Console.WriteLine();
            Console.WriteLine("Tarefas Incompletas: ");
            Console.WriteLine();

            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa.percentual != "100%")
                    Console.WriteLine(configuracaoColunasTabela, tarefa.id, tarefa.titulo, tarefa.dataCriacao,
                        tarefa.dataConclusao, tarefa.percentual, tarefa.prioridade);
            }
        }

        public override Tarefa ObterRegistro()
        {
            Console.Write("Digite o título da tarefa: ");
            string tituloTarefa = Console.ReadLine();

            Console.Write("Digite a data de conculsao: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o percentual de conclusão atual da tarefa: ");
            string percentual = Console.ReadLine();

            Console.Write("Digte a prioridade (2 - alta, 1 - media, 0 - baixa): ");
            int prioridade = Convert.ToInt32(Console.ReadLine());

            Tarefa tarefa = new Tarefa(prioridade, tituloTarefa, DateTime.Now, dataConclusao, percentual);

            return tarefa;
        }

    }
}
