using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteControladores.Test
{
    /// <summary>
    /// Testes de CRUD para o banco de dados de Compromissos.
    /// </summary>
    [TestClass]
    public class TesteControladorCompromisso
    {
            ControladorCompromissos controladorCompromisso = new ControladorCompromissos();

            [TestMethod]
            public void TesteSelecaoTodosOsCompromissos()
            {
                Assert.AreNotEqual(controladorCompromisso.SelecionarTodosRegistros(), null);
            }

            [TestMethod]
            public void TesteSelecaoCompromissosPorId()
            {
                Assert.AreNotEqual(controladorCompromisso.SelecionarRegistroPorId(10), null);
            }

            [TestMethod]
            public void TesteEdicaoCompromisso()
            {
                Compromisso compromisso = controladorCompromisso.SelecionarRegistroPorId(5);
                string testeAssunto = compromisso.Assunto;
                compromisso.Assunto = "Teeeste";
                controladorCompromisso.Editar(compromisso);
                Assert.AreNotEqual(testeAssunto, compromisso.Assunto);
            }

            [TestMethod]
            public void TesteInsercaoCompromisso()
            {
                int tamanhoInicial = controladorCompromisso.SelecionarTodosRegistros().Count;
                Compromisso compromisso = new Compromisso("Alo", "qualquer",
                    new DateTime(2022,09,09), new DateTime(2022, 09, 10), "sauas.com", 0);
                controladorCompromisso.Inserir(compromisso);
                Assert.AreNotEqual(tamanhoInicial, controladorCompromisso.SelecionarTodosRegistros().Count);
            }

            [TestMethod]
            public void TesteRemocaoCompromisso()
            {
                controladorCompromisso.Excluir(3);

                Assert.AreEqual(controladorCompromisso.SelecionarRegistroPorId(3), null);
            }
        

    }
}
