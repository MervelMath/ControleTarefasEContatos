using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Controladores.ClassLibrary
{
    public class DBTarefas
    {
        #region
        string sqlInsercao =
                @"INSERT INTO TBTAREFAS
                		(
                		[TITULO], 
                		[DATACRIACAO], 
                		[DATACONCLUSAO], 
                		[PERCENTUAL],
                        [PRIORIDADE]
                		)
                
                VALUES
                		(
                		@TITULO, 
                		@DATACRIACAO, 
                		@DATACONCLUSAO, 
                		@PERCENTUAL,
                        @PRIORIDADE
                		);";

        string sqlSelecaoTodos =
                            @"
                    SELECT 
                         [ID],
                         [TITULO],
                         [DATACRIACAO],
                         [DATACONCLUSAO],
                         [PERCENTUAL],
                         [PRIORIDADE]
                    FROM 
                         TBTAREFAS
                    ORDER BY
		                 [PRIORIDADE] DESC";

        string sqlEdicao =
                    @"UPDATE TBTAREFAS 
	                   	SET
			                [TITULO] = @TITULO,
			                [DATACRIACAO] = @DATACRIACAO,
			                [DATACONCLUSAO] = @DATACONCLUSAO,
			                [PERCENTUAL] = @PERCENTUAL,
			                [PRIORIDADE] = @PRIORIDADE
		                 WHERE
		                    [ID] = @ID";

        string sqlExclusao =
                @"DELETE FROM TBTAREFAS 
		                 WHERE
		                    [ID] = @ID";

        string sqlSelecao =
                    @"
                SELECT 
                    [ID],
                    [TITULO],
                    [DATACRIACAO],
                    [DATACONCLUSAO],
                    [PERCENTUAL],
                    [PRIORIDADE]
                 FROM 
                    TBTAREFAS
                 WHERE
                     ID = @ID";
        #endregion

        public void InserirSQLI(Tarefa obj, SQLiteConnection conexaoComBancoSQLite)
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();


            SQLiteCommand comandoInsercao = new SQLiteCommand();

            comandoInsercao.Connection = conexaoComBancoSQLite;

            
            sqlInsercao +=
                @"SELECT LAST_INSERT_ROWID();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", obj.titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", obj.dataCriacao);
            comandoInsercao.Parameters.AddWithValue("DATACONCLUSAO", obj.dataConclusao);
            comandoInsercao.Parameters.AddWithValue("PERCENTUAL", obj.percentual);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", obj.prioridade);

            object id = comandoInsercao.ExecuteScalar();

            obj.id = Convert.ToInt32(id);
            conexaoComBancoSQLite.Close();
        }

        public void InserirSQLS(Tarefa obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

            
            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY()";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", obj.titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", obj.dataCriacao);
            comandoInsercao.Parameters.AddWithValue("DATACONCLUSAO", obj.dataConclusao);
            comandoInsercao.Parameters.AddWithValue("PERCENTUAL", obj.percentual);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", obj.prioridade);

            object id = comandoInsercao.ExecuteScalar();

            obj.id = Convert.ToInt32(id);
            conexaoComBanco.Close();
        }

        public List<Tarefa> SlecionarTodosSQLI(SQLiteConnection conexaoComBancoSQLite)
        {
            
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();


            SQLiteCommand comandoSelecao = new SQLiteCommand();

            comandoSelecao.Connection = conexaoComBancoSQLite;


            comandoSelecao.CommandText = sqlSelecaoTodos;

            SQLiteDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);
                string titulo = (leitorTarefas["TITULO"]).ToString();
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefa tarefa = new Tarefa(prioridade, titulo, dataCriacao, dataConclusao, percentual);

                tarefa.id = id;

                tarefas.Add(tarefa);

            }

            conexaoComBancoSQLite.Close();
            return tarefas;
        }

        public List<Tarefa> SlecionarTodosSQLS(SqlConnection conexaoComBanco)
        {

            List<Tarefa> tarefas = new List<Tarefa>();

            conexaoComBanco.Close();
            conexaoComBanco.Open();

            using (SqlCommand comandoSelecao = new SqlCommand())
            {

                comandoSelecao.Connection = conexaoComBanco;


                comandoSelecao.CommandText = sqlSelecaoTodos;

                using (SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader())
                {


                    while (leitorTarefas.Read())
                    {
                        int id = Convert.ToInt32(leitorTarefas["ID"]);
                        string titulo = (leitorTarefas["TITULO"]).ToString();
                        DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                        DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                        string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
                        int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                        Tarefa tarefa = new Tarefa(prioridade, titulo, dataCriacao, dataConclusao, percentual);

                        tarefa.id = id;

                        tarefas.Add(tarefa);

                    }
                }
            }
            conexaoComBanco.Close();
            return tarefas;
        }

        public void EditarComSQLI(Tarefa obj, SQLiteConnection conexaoComBancoSQLite)
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();


            using (SQLiteCommand comandoEdicao = new SQLiteCommand())
            {

                comandoEdicao.Connection = conexaoComBancoSQLite;

                
                comandoEdicao.CommandText = sqlEdicao;


                comandoEdicao.Parameters.AddWithValue("ID", obj.id);
                comandoEdicao.Parameters.AddWithValue("TITULO", obj.titulo);
                comandoEdicao.Parameters.AddWithValue("DATACRIACAO", obj.dataCriacao);
                comandoEdicao.Parameters.AddWithValue("DATACONCLUSAO", obj.dataConclusao);
                comandoEdicao.Parameters.AddWithValue("PERCENTUAL", obj.percentual);
                comandoEdicao.Parameters.AddWithValue("PRIORIDADE", obj.prioridade);

                comandoEdicao.ExecuteNonQuery();
            }
            conexaoComBancoSQLite.Close();
        }

        public void EditarComSQLS(Tarefa obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            using (SqlCommand comandoEdicao = new SqlCommand())
            {
                comandoEdicao.Connection = conexaoComBanco;

                comandoEdicao.CommandText = sqlEdicao;


                comandoEdicao.Parameters.AddWithValue("ID", obj.id);
                comandoEdicao.Parameters.AddWithValue("TITULO", obj.titulo);
                comandoEdicao.Parameters.AddWithValue("DATACRIACAO", obj.dataCriacao);
                comandoEdicao.Parameters.AddWithValue("DATACONCLUSAO", obj.dataConclusao);
                comandoEdicao.Parameters.AddWithValue("PERCENTUAL", obj.percentual);
                comandoEdicao.Parameters.AddWithValue("PRIORIDADE", obj.prioridade);

                comandoEdicao.ExecuteNonQuery();
            }
            conexaoComBanco.Close();
        }

        public void ExcluirComSQLI(int id, SQLiteConnection conexaoComBancoSQLite)
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();

            SQLiteCommand comandoExcluir = new SQLiteCommand();

            comandoExcluir.Connection = conexaoComBancoSQLite;

            

            comandoExcluir.CommandText = sqlExclusao;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBancoSQLite.Close();
        }

        public void ExcluirComSQLS(int id, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoExcluir = new SqlCommand();

            comandoExcluir.Connection = conexaoComBanco;

            comandoExcluir.CommandText = sqlExclusao;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public Tarefa SelecionarPorIdComSQLI(int idPesquisado, SQLiteConnection conexaoComBancoSQLite)
        {
            Tarefa tarefa;
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();

            using (SQLiteCommand comandoSelecao = new SQLiteCommand())
            {
                comandoSelecao.Connection = conexaoComBancoSQLite;

                

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SQLiteDataReader leitorTarefas = comandoSelecao.ExecuteReader())
                {
                    if (leitorTarefas.Read() == false) return null;

                    int id = Convert.ToInt32(leitorTarefas["ID"]);
                    string titulo = (leitorTarefas["TITULO"]).ToString();
                    DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                    DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                    string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
                    int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                    tarefa = new Tarefa(prioridade, titulo, dataCriacao, dataConclusao, percentual);

                    tarefa.id = id;
                }
            }
            conexaoComBancoSQLite.Close();
            return tarefa;
        }

        public Tarefa SelecionarPorIdComSQLS(int idPesquisado, SqlConnection conexaoComBanco)
        {
            Tarefa tarefa;
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            using (SqlCommand comandoSelecao = new SqlCommand())
            {
                comandoSelecao.Connection = conexaoComBanco;

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader())
                {
                    if (leitorTarefas.Read() == false) return null;

                    int id = Convert.ToInt32(leitorTarefas["ID"]);
                    string titulo = (leitorTarefas["TITULO"]).ToString();
                    DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                    DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                    string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
                    int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                    tarefa = new Tarefa(prioridade, titulo, dataCriacao, dataConclusao, percentual);

                    tarefa.id = id;
                }
            }
            conexaoComBanco.Close();
            return tarefa;

        }
    }
}