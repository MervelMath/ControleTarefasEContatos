using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Controladores.ClassLibrary
{
    public class ControladorTarefa : ControladorBase<Tarefa>
    {
        DBTarefas db = new DBTarefas();

        public override List<Tarefa> SelecionarTodosRegistros()
        {
            List<Tarefa> tarefas = null;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                tarefas = db.SlecionarTodosSQLI(conexaoComBancoSQLite);

            else
                tarefas = db.SlecionarTodosSQLS(conexaoComBanco);

            return tarefas;
        }

        public override void Editar(Tarefa obj)
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

        public override void Inserir(Tarefa obj)
        {
            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                db.InserirSQLI(obj, conexaoComBancoSQLite);

            else
                db.InserirSQLS(obj, conexaoComBanco);
        }

        public override Tarefa SelecionarRegistroPorId(int idPesquisado)
        {
            Tarefa tarefa;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                tarefa = db.SelecionarPorIdComSQLI(idPesquisado, conexaoComBancoSQLite);

            else
                tarefa = db.SelecionarPorIdComSQLS(idPesquisado, conexaoComBanco);

            return tarefa;
        }
    }
}
