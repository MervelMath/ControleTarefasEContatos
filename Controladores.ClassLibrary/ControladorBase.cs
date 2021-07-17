using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Controladores.ClassLibrary
{
    public abstract class ControladorBase<T> where T : EntidadeBase
    {
        //Para usar o SQLServer, mude o "name" da "connection string" para "DBeAgendaSQLS".
        //Para usar o SQLite, mude o "name" da "connection string" para "DBeAgendaSQLI".
        protected static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString;
        
        protected SqlConnection conexaoComBanco = new SqlConnection(connectionString);
        protected SQLiteConnection conexaoComBancoSQLite = new SQLiteConnection(connectionString);


        public abstract void Inserir(T obj);

        public abstract void Excluir(int id);

        public abstract void Editar(T obj);

        public virtual List<T> SelecionarTodosRegistros()
        {
            return new List<T>();
        }

        public string VerificarInsercao(T obj)
        {
            string resultadoValidacao = obj.Validar();

            if (resultadoValidacao == "VALIDA")
            {
                if (ExisteEntidadeComEsteId(obj.id))
                    Editar(obj);
                else
                    Inserir(obj);
            }

            return resultadoValidacao;
        }

        public bool ExisteEntidadeComEsteId(int id)
        {
            return SelecionarRegistroPorId(id) != null;
        }

        public abstract T SelecionarRegistroPorId(int idPesquisado);

        public bool VerificarExclusao(int id)
        {
            if (ExisteEntidadeComEsteId(id))
            {
                Excluir(id);
                return true;
            }

            return false;
        }
    }
}
