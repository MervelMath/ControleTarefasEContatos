using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteControladores.Test
{
    [TestClass]
    public class TesteControladorCompromisso
    {
        ControladorCompromissos controlador;
        ResetDB dB;
        public TesteControladorCompromisso()
        {
            controlador = new ControladorCompromissos();
            dB = new ResetDB();
            dB.DeleteSQLI(@"DELETE FROM [TBCARTOES];");
            dB.DeleteSQLS(@"DELETE FROM [TBCARTOES];");
            dB.DeleteSQLI(@"DELETE FROM [TBTAREFAS];");
            dB.DeleteSQLS(@"DELETE FROM [TBTAREFAS];");
            dB.DeleteSQLI(@"DELETE FROM [TBCOMPROMISSOS];");
            dB.DeleteSQLS(@"DELETE FROM [TBCOMPROMISSOS];");
        }

        [TestMethod]
        public void DeveInserir_CompromissoSem_Contato()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021,10,10), new DateTime(2022, 10, 10), "www.teste.com", 0);
            compromisso.nomeContato = "";
            //action
            controlador.Inserir(compromisso);

            //assert
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);
            compromissoEncontrado.Should().Be(compromisso);
        }

        [TestMethod]
        public void DeveInserir_CompromissoCom_Contato()
        {
            ControladorCartoesContatos controladorCartoesContatos = new ControladorCartoesContatos();
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controladorCartoesContatos.Inserir(contato);
            //arrange
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021, 10, 10), new DateTime(2022, 10, 10), "www.teste.com", contato.id);

            //action
            controlador.Inserir(compromisso);

            //assert
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);
            compromissoEncontrado.idContato.Should().Be(contato.id);
        }

        [TestMethod]
        public void DeveEditar_UmCompromisso()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021, 10, 10), new DateTime(2022, 10, 10), "www.teste.com", 0);
            compromisso.nomeContato = "";
            controlador.Inserir(compromisso);

            string assuntoAux = compromisso.Assunto;

            compromisso.Assunto = "Estratégias";

            //action
            controlador.Editar(compromisso);

            //assert
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);
            assuntoAux.Should().NotBe(compromissoEncontrado.Assunto);
        }

        [TestMethod]
        public void DeveExcluir_UmCompromisso()
        {
            //arrange            
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021, 10, 10), new DateTime(2022, 10, 10), "www.teste.com", 0);
            compromisso.nomeContato = "";
            controlador.Inserir(compromisso);


            //action            
            controlador.Excluir(compromisso.id);

            //assert
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);
            compromissoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Compromisso_PorId()
        {
            //arrange
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021, 10, 10), new DateTime(2022, 10, 10), "www.teste.com", 0);
            compromisso.nomeContato = "";
            controlador.Inserir(compromisso);

            //action
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);

            //assert
            compromissoEncontrado.Should().Be(compromisso);
        }

        [TestMethod]
        public void DeveRemover_Compromisso_ComContatoExcluido()
        {
            ControladorCartoesContatos controladorCartoesContatos = new ControladorCartoesContatos();
            CartoesDeContatos contato = new CartoesDeContatos("Matheus", "teste@gmail.com", 12345678, "NDD", "Estagiário");
            controladorCartoesContatos.Inserir(contato);
            //arrange
            Compromisso compromisso = new Compromisso("Negócios", "Bangu", new DateTime(2021, 10, 10), new DateTime(2022, 10, 10), "www.teste.com", contato.id);

            //action
            controlador.Inserir(compromisso);
            controladorCartoesContatos.Excluir(contato.id);

            //assert
            Compromisso compromissoEncontrado = controlador.SelecionarRegistroPorId(compromisso.id);
            compromissoEncontrado.Should().BeNull();
        }
    }
}
