using Controladores.ClassLibrary;
using Controladores.ClassLibrary.ContatosModule;
using Dominios.ClassLibrary;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteControladores.Test
{
    [TestClass]
    public class TesteControladorCartoesContato
    {

        ControladorCartoesContatos controlador;
        ResetDB dB;

        public TesteControladorCartoesContato()
        {
            controlador = new ControladorCartoesContatos();
            dB = new ResetDB();
            dB.DeleteSQLI(@"DELETE FROM [TBCARTOES];");
            dB.DeleteSQLS(@"DELETE FROM [TBCARTOES];");
        }

        [TestMethod]
        public void DeveInserir_Contato()
        {
            //arrange
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");

            //action
            controlador.Inserir(contato);

            //assert
            CartoesDeContatos cartaoDeCOntatoEncontrado = controlador.SelecionarRegistroPorId(contato.id);
            cartaoDeCOntatoEncontrado.Should().Be(contato);
        }

        [TestMethod]
        public void DeveEditar_UmContato()
        {
            //arrange
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controlador.Inserir(contato);

            string cargoAux = contato.cargo;

            contato.cargo = "Desenvolvedor";

            //action
            controlador.Editar(contato);

            //assert
            CartoesDeContatos contatoEncontrado = controlador.SelecionarRegistroPorId(contato.id);
            cargoAux.Should().NotBe(contatoEncontrado.cargo);
        }

        [TestMethod]
        public void DeveExcluir_UmContato()
        {
            //arrange            
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controlador.Inserir(contato);


            //action            
            controlador.Excluir(contato.id);

            //assert
            CartoesDeContatos contatoEncontrado = controlador.SelecionarRegistroPorId(contato.id);
            contatoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Tarefa_PorId()
        {
            //arrange
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controlador.Inserir(contato);

            //action
            CartoesDeContatos contatoEncontrado = controlador.SelecionarRegistroPorId(contato.id);

            //assert
            contatoEncontrado.Should().Be(contato);
        }

        public void DeveSelecionar_TodosOsContatos_OrdenadosPorCargo()
        {
            //arrange
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controlador.Inserir(contato);

            CartoesDeContatos contato2 = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Funcionario");
            controlador.Inserir(contato2);

            CartoesDeContatos contato3 = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controlador.Inserir(contato3);


            //action
            var contatos = controlador.SelecionarTodosRegistros();

            //assert
            contatos.Should().HaveCount(3);
            contatos[0].cargo.Should().Be("Estagiério");
            contatos[1].cargo.Should().Be("Estagiério");
            contatos[2].cargo.Should().Be("Funcionario");
        }
    }
}
