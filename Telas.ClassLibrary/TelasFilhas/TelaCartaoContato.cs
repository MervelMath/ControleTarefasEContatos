using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using Telas.ClassLibrary.TelasMae;

namespace Telas.ClassLibrary
{
    public class TelaCartaoContato : TelaCadastroBasico<CartoesDeContatos>, ICadastravel
    {

        public TelaCartaoContato(ControladorBase<CartoesDeContatos> controlador) : base(controlador, "Tela de Contatos", "contato")
        {
        }

        public override void MontarTabela(List<CartoesDeContatos> cartoes)
        {

            string configuracaoColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3, -20} | {4, -10} | {5, -10}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Nome", "Email",
                "Telefone", "Empresa", "Cargo");

            foreach (CartoesDeContatos cartao in cartoes)
            {
                Console.WriteLine(configuracaoColunasTabela, cartao.id, cartao.nome, cartao.email,
                    cartao.telefone, cartao.empresa, cartao.cargo);
            }
        }

        public override CartoesDeContatos ObterRegistro()
        {
            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do contato: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do contato: ");
            string testeTelefone = (Console.ReadLine());

            int telefone =0;

            if(!Int32.TryParse(testeTelefone, out telefone))
            {
                Console.WriteLine("Número de telefone inválido! Tente novamente...");
                Console.ReadLine();

                return ObterRegistro();
            }


            Console.Write("Digite o nome da empresa: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o cargo do contato: ");
            string cargo = Console.ReadLine();

            CartoesDeContatos cartoes = new CartoesDeContatos(nome, email, telefone, empresa, cargo);

            return cartoes;
        }

    }
}
