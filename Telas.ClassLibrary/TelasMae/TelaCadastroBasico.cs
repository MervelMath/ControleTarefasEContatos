using Controladores.ClassLibrary;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
namespace Telas.ClassLibrary.TelasMae
{
    public abstract class TelaCadastroBasico<T> : TelaBase, ICadastravel where T : EntidadeBase
    {
        private readonly ControladorBase<T> controladorRegistro;
        private string tituloDaTela;

        public TelaCadastroBasico(ControladorBase<T> controlador, string tituloDaTelaBase, string tipoTela)
            : base(tituloDaTelaBase)
        {
            this.tituloDaTela = tipoTela;
            controladorRegistro = controlador;
        }

        public void EditarRegistro()
        {
            ConfigurarTela($"Editando {tituloDaTela}...");

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write($"\nDigite o número do(a) {tituloDaTela} que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorRegistro.ExisteEntidadeComEsteId(id);

            if (numeroEncontrado == false)
            {
                ApresentarMensagem($"Nenhum(a) {tituloDaTela} foi encontrado com este número: " + id, TipoMensagem.Erro);
                EditarRegistro();
                return;
            }

            T registro = ObterRegistro();

            registro.id = id;

            string resultadoValidacao = controladorRegistro.VerificarInsercao(registro);

            if (resultadoValidacao == "VALIDA")
                ApresentarMensagem($"{tituloDaTela} editado(a) com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                EditarRegistro();
            }
        }


        public void ExcluirRegistro()
        {
            ConfigurarTela($"Excluindo um(a) {tituloDaTela}...");

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write($"\nDigite o número do(a) {tituloDaTela} que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorRegistro.ExisteEntidadeComEsteId(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem($"Nenhum(a) {tituloDaTela} foi encontrado(a) com este número: " + id, TipoMensagem.Erro);
                ExcluirRegistro();
                return;
            }

            bool conseguiuExcluir = controladorRegistro.VerificarExclusao(id);

            if (conseguiuExcluir)
                ApresentarMensagem($"{tituloDaTela} excluído(a) com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem($"Falha ao tentar excluir o(a) {tituloDaTela}", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }
        public void InserirNovoRegistro()
        {
            ConfigurarTela($"Inserindo um(a) novo(a) {tituloDaTela}...");

            T registro = ObterRegistro();

            string resultadoValidacao = controladorRegistro.VerificarInsercao(registro);

            if (resultadoValidacao == "VALIDA")
                ApresentarMensagem($"{tituloDaTela} inserido(a) com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public abstract T ObterRegistro();

        public bool VisualizarRegistros(TipoVisualizacao tipo)
        {

            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela($"Visualizando {tituloDaTela}s...");

            List<T> registros = controladorRegistro.SelecionarTodosRegistros();

            if (registros.Count == 0)
            {
                ApresentarMensagem($"Nenhum(a) {tituloDaTela} cadastrado!", TipoMensagem.Atencao);
                Console.ReadLine();
                return false;
            }

            MontarTabela(registros);

            Console.ReadLine();

            return true;
        }

        public abstract void MontarTabela(List<T> registros);

    }
}
