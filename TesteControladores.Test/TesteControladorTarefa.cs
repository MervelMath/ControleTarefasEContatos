using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteControladores.Test
{
    [TestClass]
    public class TesteControladorTarefa
    {
        ControladorTarefa controladorTarefa = new ControladorTarefa();

        [TestMethod]
        public void TesteSelecaoTodasAsTarefas()
        {
            Assert.AreNotEqual(controladorTarefa.SelecionarTodosRegistros(), null);
        }

        [TestMethod]
        public void TesteSelecaoTarefaPorId()
        {
            Assert.AreNotEqual(controladorTarefa.SelecionarRegistroPorId(15), null);
        }

        [TestMethod]
        public void TesteEdicaoTarefa()
        {
            Tarefa tarefa = controladorTarefa.SelecionarRegistroPorId(15);
            string testeTitulo = tarefa.titulo;
            tarefa.titulo = "Novo Titulooo";
            controladorTarefa.Editar(tarefa);
            Assert.AreNotEqual(testeTitulo, tarefa.titulo);
        }

        [TestMethod]
        public void TesteInsercaoTarefa()
        {
            int tamanhoInicial = controladorTarefa.SelecionarTodosRegistros().Count;
            Tarefa tarefa = new Tarefa(1, "Teste", DateTime.Now, new DateTime(2022,10,2), "10%");
            controladorTarefa.Inserir(tarefa);
            Assert.AreNotEqual(tamanhoInicial, controladorTarefa.SelecionarTodosRegistros().Count);
        }

        [TestMethod]
        public void TesteRemocaoTarefa()
        {
            controladorTarefa.Excluir(16);

            Assert.AreEqual(controladorTarefa.SelecionarRegistroPorId(16), null);
        }
    }
}
