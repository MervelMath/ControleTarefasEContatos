using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteDominios.Test
{
    [TestClass]
    public class TesteTarefa
    {
        [TestMethod]
        public void TesteValidacaoDataTarefa()
        {
            Tarefa tarefa = new Tarefa(1, "", DateTime.Now, new DateTime(2020,2,2), "2%");
            Assert.AreEqual(tarefa.Validar(), "A data de conclusão não pode ser menor que a atual.");
        }
        
        [TestMethod]
        public void TesteValidacaoPrioridadeTarefa()
        {
            Tarefa tarefa = new Tarefa(-1, "", DateTime.Now, new DateTime(2022,2,2), "2%");
            Assert.AreEqual(tarefa.Validar(), "Prioridade inválida");
        }
    }
}
