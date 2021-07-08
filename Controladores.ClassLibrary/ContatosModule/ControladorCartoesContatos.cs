using Controladores.ClassLibrary.ContatosModule;
using Dominios.ClassLibrary;
using System.Collections.Generic;
using System.Configuration;

namespace Controladores.ClassLibrary
{
    public class ControladorCartoesContatos : ControladorBase<CartoesDeContatos>
    {
        DBContatos db = new DBContatos();

        public override CartoesDeContatos SelecionarRegistroPorId(int idPesquisado)
        {
            CartoesDeContatos cartao;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                cartao = db.SelecionarPorIdComSQLI(idPesquisado, conexaoComBancoSQLite);

            else
                cartao = db.SelecionarPorIdComSQLS(idPesquisado, conexaoComBanco);

            return cartao;
        }

        public override List<CartoesDeContatos> SelecionarTodosRegistros()
        {
            List<CartoesDeContatos> cartoes = null;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                cartoes = db.SlecionarTodosSQLI(conexaoComBancoSQLite);

            else
                cartoes = db.SlecionarTodosSQLS(conexaoComBanco);

            return cartoes;
        }

        public override void Editar(CartoesDeContatos obj)
        {
            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                db.EditarComSQLI(obj, conexaoComBancoSQLite);

            else
                db.EditarComSQLS(obj, conexaoComBanco);
        }

        public override void Excluir(int id)
        {
            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                db.ExcluirComSQLI(id, conexaoComBancoSQLite);
            else
                db.ExcluirComSQLS(id, conexaoComBanco);
        }

        public override void Inserir(CartoesDeContatos obj)
        {
            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                db.InserirSQLI(obj, conexaoComBancoSQLite);

            else
                db.InserirSQLS(obj, conexaoComBanco);
        }
    }
}
