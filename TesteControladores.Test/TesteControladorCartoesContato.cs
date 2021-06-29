using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteControladores.Test
{
    [TestClass]
    public class TesteControladorCartoesContato
    {

        ControladorCartoesContatos controladorCartoesContatos = new ControladorCartoesContatos();

        [TestMethod]
        public void TesteSelecaoTodasAsCartoes()
        {
            Assert.AreNotEqual(controladorCartoesContatos.SelecionarTodosRegistros(), null);
        }

        [TestMethod]
        public void TesteSelecaoCartoesPorId()
        {
            Assert.AreNotEqual(controladorCartoesContatos.SelecionarRegistroPorId(3), null);
        }

        [TestMethod]
        public void TesteEdicaoCartao()
        {
            CartoesDeContatos cartoes = controladorCartoesContatos.SelecionarRegistroPorId(3);
            string testeNome = cartoes.nome;
            cartoes.nome = "Teeeste";
            controladorCartoesContatos.Editar(cartoes);
            Assert.AreNotEqual(testeNome, cartoes.nome);
        }

        [TestMethod]
        public void TesteInsercaoCartao()
        {
            int tamanhoInicial = controladorCartoesContatos.SelecionarTodosRegistros().Count;
            CartoesDeContatos cartao = new CartoesDeContatos("Alooooohh", "matheus@gmail.com",
                31820, "empr", "func");
            controladorCartoesContatos.Inserir(cartao);
            Assert.AreNotEqual(tamanhoInicial, controladorCartoesContatos.SelecionarTodosRegistros().Count);
        }

        [TestMethod]
        public void TesteRemocaoCartao()
        {
            controladorCartoesContatos.Excluir(4);

            Assert.AreEqual(controladorCartoesContatos.SelecionarRegistroPorId(4), null);
        }
    }
}
