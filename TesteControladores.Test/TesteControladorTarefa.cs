using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteControladores.Test
{
    [TestClass]
    public class TesteControladorTarefa
    {
        ControladorTarefa controlador;
        ResetDB dB;
        
        public TesteControladorTarefa()
        {
            controlador = new ControladorTarefa();
            dB = new ResetDB();
            dB.DeleteSQLI(@"DELETE FROM [TBTAREFAS];");
            dB.DeleteSQLS(@"DELETE FROM [TBTAREFAS];");
        }

        [TestMethod]
        public void DeveInserir_Tarefa()
        {
            //arrange
            Tarefa tarefa = new Tarefa(1, "Teste", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");

            //action
            controlador.Inserir(tarefa);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarRegistroPorId(tarefa.id);
            tarefaEncontrada.Should().Be(tarefa);
        }

        [TestMethod]
        public void DeveEditar_UmaTarefa()
        {
            //arrange
            Tarefa tarefa = new Tarefa(1, "Teste", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa);

            string tituloAux = tarefa.titulo;

            tarefa.titulo = "Novo Teste";

            //action
            controlador.Editar(tarefa);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarRegistroPorId(tarefa.id);
            tituloAux.Should().NotBe(tarefaEncontrada.titulo);
        }

        [TestMethod]
        public void DeveExcluir_UmaTarefa()
        {
            //arrange            
            Tarefa tarefa = new Tarefa(1, "Teste", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa);

            //action            
            controlador.Excluir(tarefa.id);

            //assert
            Tarefa tarefaEncontrada = controlador.SelecionarRegistroPorId(tarefa.id);
            tarefaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Tarefa_PorId()
        {
            //arrange
            Tarefa tarefa = new Tarefa(1, "Teste", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa);

            //action
            Tarefa tarefaEncontrada = controlador.SelecionarRegistroPorId(tarefa.id);

            //assert
            tarefaEncontrada.Should().Be(tarefa);
        }

        [TestMethod]
        public void DeveSelecionar_TodasTarefas_OrdenadasPorPrioridade()
        {
            //arrange
            Tarefa tarefa1 = new Tarefa(1, "Teste1", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa1);

            Tarefa tarefa2 = new Tarefa(1, "Teste2", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa2);

            Tarefa tarefa3 = new Tarefa(1, "Teste3", new DateTime(2021, 10, 2), new DateTime(2022, 10, 2), "10%");
            controlador.Inserir(tarefa3);


            //action
            var tarefas = controlador.SelecionarTodosRegistros();

            //assert
            tarefas.Should().HaveCount(3);
            tarefas[0].titulo.Should().Be("Teste1");
            tarefas[1].titulo.Should().Be("Teste2");
            tarefas[2].titulo.Should().Be("Teste3");
        }


    }
}
