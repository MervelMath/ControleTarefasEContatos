using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDominios.Test
{
    /// <summary>
    /// Summary description for TesteCompromisso
    /// </summary>
    [TestClass]
    public class TesteCompromisso
    {
        [TestMethod]
        public void TesteLinkSemFinal()
        {
            Compromisso cartao = new Compromisso("", "", new DateTime(2023,09,09), new DateTime(2023, 09, 10), "teste", 0);
            Assert.AreEqual(cartao.Validar(), "O link não contém o finalizador '.com'!");
        }

        [TestMethod]
        public void TesteDataInicioMenorQueAtual()
        {
            Compromisso cartao = new Compromisso("", "", new DateTime(2020, 09, 09), new DateTime(2023, 09, 10), "teste.com", 0);
            Assert.AreEqual(cartao.Validar(), "A data do compromisso não pode ser menor que a atual.");
        }

        [TestMethod]
        public void TesteDataInicioMenorQueDataFinal()
        {
            Compromisso cartao = new Compromisso("", "", new DateTime(2022, 09, 09), new DateTime(2021, 09, 10), "teste.com", 0);
            Assert.AreEqual(cartao.Validar(), "A data de início do compromisso não pode ser menor que a data de término.");
        }
    }
}
