using System;
using Telas.ClassLibrary;
using Telas.ClassLibrary.TelasMae;

namespace TarefasDNF.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)

        {
            TelaInicial telaInicial = new TelaInicial();
            string opcao = null;
            TelaBase telaSelecionada = null;
            do
            {
                telaSelecionada = telaInicial.ObterTela();
                if (telaSelecionada == null)
                    break;

                Console.Clear();
                opcao = telaSelecionada.ObterOpcao();

                if (telaSelecionada is ICadastravel)
                {
                    ICadastravel tela = (ICadastravel)telaSelecionada;

                    switch (opcao)
                    {
                        case "1": tela.InserirNovoRegistro(); break;

                        case "2": tela.VisualizarRegistros(TipoVisualizacao.VisualizandoTela); break;

                        case "3": tela.EditarRegistro(); break;

                        case "4": tela.ExcluirRegistro(); break;

                    }

                }
            } while (true);

        }
    }
}
