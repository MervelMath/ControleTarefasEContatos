using Controladores.ClassLibrary.CompromissosModule;
using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Controladores.ClassLibrary
{
    public class ControladorCompromissos : ControladorBase<Compromisso>
    {
        DBCompromissos db = new DBCompromissos();
        public override Compromisso SelecionarRegistroPorId(int idPesquisado)
        {

            Compromisso compromisso;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                compromisso = db.SelecionarPorIdComSQLI(idPesquisado, conexaoComBancoSQLite);

            else
                compromisso = db.SelecionarPorIdComSQLS(idPesquisado, conexaoComBanco);

            return compromisso;
        }

        public override List<Compromisso> SelecionarTodosRegistros()
        {
            List<Compromisso> compromissos = null;

            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                compromissos = db.SlecionarTodosSQLI(conexaoComBancoSQLite);

            else
                compromissos = db.SlecionarTodosSQLS(conexaoComBanco);

            return compromissos;
        }

        public override void Editar(Compromisso obj)
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

        public override void Inserir(Compromisso obj)
        {
            if (connectionString == ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString)
                db.InserirSQLI(obj, conexaoComBancoSQLite);

            else
                db.InserirSQLS(obj, conexaoComBanco);
        }

    }
}
