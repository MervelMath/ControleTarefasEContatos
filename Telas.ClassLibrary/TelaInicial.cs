﻿using Controladores.ClassLibrary;
using System;
using Telas.ClassLibrary.TelasMae;

namespace Telas.ClassLibrary
{
    public class TelaInicial : TelaBase
    {
        static TelaCartaoContato telaContatos;
        static TelaTarefa telaTarefas;
        ControladorTarefa controladorTarefa = new ControladorTarefa();
        ControladorCartoesContatos controladorCartoes = new ControladorCartoesContatos();

        public TelaInicial() : base("Menu Inicial")
        {
            telaContatos = new TelaCartaoContato(controladorCartoes);
            telaTarefas = new TelaTarefa(controladorTarefa);
        }

        public TelaBase ObterTela()
        {
            ConfigurarTela("Escolha uma opção: ");

            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para entrar no controle de tarefas.");
                Console.WriteLine("Digite 2 para entrar no controle de cartões de contato.");

                Console.WriteLine("Digite S para Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = telaTarefas;

                if (opcao == "2")
                    telaSelecionada = telaContatos;

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }


        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "s")
            {
                ApresentarMensagem("Opção inválida", TipoMensagem.Erro);
                return true;
            }
            else
                return false;
        }
    }
}
