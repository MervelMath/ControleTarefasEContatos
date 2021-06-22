using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDominios.Test
{
    [TestClass]
    public class TesteDominios
    {
        [TestMethod]
        public void TesteValidacaoEmailSemfinal()
        {
            CartoesDeContatos cartao = new CartoesDeContatos("", "matheus@", 312,"", "");
            Assert.AreEqual(cartao.Validar(), "O email não contém o finalizador '.com'!");
        }

        [TestMethod]
        public void TesteValidacaoEmailSemDominio()
        {
            CartoesDeContatos cartao = new CartoesDeContatos("", "matheus.com", 312, "", "");
            Assert.AreEqual(cartao.Validar(), "O email não contém um domínio com '@'.");
        }
        
        [TestMethod]
        public void TesteValidacaoTelefonePequeno()
        {
            CartoesDeContatos cartao = new CartoesDeContatos("", "matheus@.com", 312, "", "");
            Assert.AreEqual(cartao.Validar(), "O número de telefone é muito pequeno.");
        }


    }


}

