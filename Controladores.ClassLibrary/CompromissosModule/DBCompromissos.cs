using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary.CompromissosModule
{
    public class DBCompromissos
    {
        #region
        string sqlInsercao =
                @"
                        insert into TBCOMPROMISSOS
                		(
                		[ASSUNTO], 
                		[LOCAL], 
                		[DATAINICIO], 
                		[LINKREUNIAO],
                		[IDCONTATO],
                        [DATAFIM]
                		)
                
                values
                		(
                		@ASSUNTO,
                		@LOCAL,
                		@DATAINICIO,
                		@LINKREUNIAO,
                		@IDCONTATO,
                        @DATAFIM
                		);";

        string sqlEdicao =
                @"
                    UPDATE TBCOMPROMISSOS 
		             SET
		             	[ASSUNTO] = @ASSUNTO,
		             	[LOCAL] = @LOCAL,
		             	[DATAINICIO] = @DATAINICIO,
		             	[LINKREUNIAO] = @LINKREUNIAO,
		             	[IDCONTATO] = @IDCONTATO,
                        [DATAFIM] = @DATAFIM
		             WHERE
		             	[ID] = @ID";

        string sqlSelecao =
                @"
                               
                SELECT 
	            	CP.[ID],
	            	CP.[ASSUNTO], 
	            	CP.[LOCAL], 
	            	CP.[DATAINICIO], 
	            	CP.[LINKREUNIAO],
	            	CP.[IDCONTATO],
                    CP.[DATAFIM],
                    CR.[NOME]
	            FROM
	            	TBCOMPROMISSOS CP LEFT JOIN
	            	TBCARTOES CR
	            ON
	            	CP.IDCONTATO = CR.ID
                WHERE 
                    CP.ID = @ID";

        string sqlSelecaoTodos =
                @"
                SELECT 
	            	CP.[ID],
	            	CP.[ASSUNTO], 
	            	CP.[LOCAL], 
	            	CP.[DATAINICIO], 
	            	CP.[LINKREUNIAO],
	            	CP.[IDCONTATO],
                    CP.[DATAFIM],
                    CR.[NOME]
	            FROM
	            	TBCOMPROMISSOS CP LEFT JOIN 
	            	TBCARTOES CR
	            ON
	            	CP.IDCONTATO = CR.ID";

        string sqlExclusao =
                @"
                    DELETE FROM TBCOMPROMISSOS 
		                 WHERE
		                    [ID] = @ID";

        #endregion

        public void AtivarChaveEstrangeira(SQLiteConnection conexaoComBancoSQLite)
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();

            SQLiteCommand comando = new SQLiteCommand();

            comando.CommandText = "PRAGMA foreign_keys = ON;";

            comando.Connection = conexaoComBancoSQLite;

            comando.ExecuteNonQuery();

        }

        public void InserirSQLI(Compromisso obj, SQLiteConnection conexaoComBancoSQLite)
        {

            AtivarChaveEstrangeira(conexaoComBancoSQLite);

            sqlInsercao +=
               @"SELECT LAST_INSERT_ROWID();";

            SQLiteCommand comandoInsercao = new SQLiteCommand();

            comandoInsercao.Connection = conexaoComBancoSQLite;

            

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("ID", obj.id);
            comandoInsercao.Parameters.AddWithValue("ASSUNTO", obj.Assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", obj.Local);
            comandoInsercao.Parameters.AddWithValue("DATAINICIO", obj.DataInicio);
            comandoInsercao.Parameters.AddWithValue("DATAFIM", obj.DataTermino);
            comandoInsercao.Parameters.AddWithValue("LINKREUNIAO", obj.LinkReuniao);
            if (obj.idContato == 0)
                comandoInsercao.Parameters.AddWithValue("IDCONTATO", DBNull.Value);
            else
                comandoInsercao.Parameters.AddWithValue("IDCONTATO", obj.idContato);

            object id = comandoInsercao.ExecuteScalar();
            obj.id = Convert.ToInt32(id);
            conexaoComBancoSQLite.Close();
        }

        public void InserirSQLS(Compromisso obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

            
            sqlInsercao +=
                @"select SCOPE_IDENTITY()";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("ID", obj.id);
            comandoInsercao.Parameters.AddWithValue("ASSUNTO", obj.Assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", obj.Local);
            comandoInsercao.Parameters.AddWithValue("DATAINICIO", obj.DataInicio);
            comandoInsercao.Parameters.AddWithValue("DATAFIM", obj.DataTermino);
            comandoInsercao.Parameters.AddWithValue("LINKREUNIAO", obj.LinkReuniao);
            if (obj.idContato == 0)
                comandoInsercao.Parameters.AddWithValue("IDCONTATO", DBNull.Value);
            else
                comandoInsercao.Parameters.AddWithValue("IDCONTATO", obj.idContato);

            object id = comandoInsercao.ExecuteScalar();
            obj.id = Convert.ToInt32(id);
            conexaoComBanco.Close();
        }

        public void EditarComSQLI(Compromisso obj, SQLiteConnection conexaoComBancoSQLite)
        {

            AtivarChaveEstrangeira(conexaoComBancoSQLite);


            SQLiteCommand comandoEdicao = new SQLiteCommand();

            comandoEdicao.Connection = conexaoComBancoSQLite;

            comandoEdicao.CommandText = sqlEdicao;

            comandoEdicao.Parameters.AddWithValue("ID", obj.id);
            comandoEdicao.Parameters.AddWithValue("ASSUNTO", obj.Assunto);
            comandoEdicao.Parameters.AddWithValue("LOCAL", obj.Local);
            comandoEdicao.Parameters.AddWithValue("DATAINICIO", obj.DataInicio);
            comandoEdicao.Parameters.AddWithValue("DATAFIM", obj.DataTermino);
            comandoEdicao.Parameters.AddWithValue("LINKREUNIAO", obj.LinkReuniao);
            if (obj.idContato == 0)
                comandoEdicao.Parameters.AddWithValue("IDCONTATO", DBNull.Value);
            else
                comandoEdicao.Parameters.AddWithValue("IDCONTATO", obj.idContato);

            comandoEdicao.ExecuteNonQuery();

            conexaoComBancoSQLite.Close();
        }

        public void EditarComSQLS(Compromisso obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoEdicao = new SqlCommand();

            comandoEdicao.Connection = conexaoComBanco;

            comandoEdicao.CommandText = sqlEdicao;

            comandoEdicao.Parameters.AddWithValue("ID", obj.id);
            comandoEdicao.Parameters.AddWithValue("ASSUNTO", obj.Assunto);
            comandoEdicao.Parameters.AddWithValue("LOCAL", obj.Local);
            comandoEdicao.Parameters.AddWithValue("DATAINICIO", obj.DataInicio);
            comandoEdicao.Parameters.AddWithValue("DATAFIM", obj.DataTermino);
            comandoEdicao.Parameters.AddWithValue("LINKREUNIAO", obj.LinkReuniao);
            if (obj.idContato == 0)
                comandoEdicao.Parameters.AddWithValue("IDCONTATO", DBNull.Value);
            else
                comandoEdicao.Parameters.AddWithValue("IDCONTATO", obj.idContato);

            comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public Compromisso SelecionarPorIdComSQLI(int idPesquisado, SQLiteConnection conexaoComBancoSQLite)
        {

            Compromisso compromisso;
            AtivarChaveEstrangeira(conexaoComBancoSQLite);

            using (SQLiteCommand comandoSelecao = new SQLiteCommand())
            {
                comandoSelecao.Connection = conexaoComBancoSQLite;

                

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SQLiteDataReader leitorCompromissos = comandoSelecao.ExecuteReader())
                {
                    if (leitorCompromissos.Read() == false) return null;

                    
                    int id = Convert.ToInt32(leitorCompromissos["ID"]);
                    string assunto = (leitorCompromissos["ASSUNTO"]).ToString();
                    string local = (leitorCompromissos["LOCAL"]).ToString();
                    DateTime dataInicio = Convert.ToDateTime(leitorCompromissos["DATAINICIO"]);
                    DateTime dataFim = Convert.ToDateTime(leitorCompromissos["DATAFIM"]);
                    string linkReuniao = Convert.ToString(leitorCompromissos["LINKREUNIAO"]);

                    int idContato = 0;

                    if (leitorCompromissos["IDCONTATO"] != DBNull.Value)
                        idContato = Convert.ToInt32(leitorCompromissos["IDCONTATO"]);

                    string nomeContato = Convert.ToString(leitorCompromissos["NOME"]);
                    compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                             linkReuniao, idContato);

                    compromisso.nomeContato = nomeContato;

                    compromisso.id = id;
                }
            }
            conexaoComBancoSQLite.Close();
            return compromisso;
        }

        public Compromisso SelecionarPorIdComSQLS(int idPesquisado, SqlConnection conexaoComBanco)
        {
            Compromisso compromisso;
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            using (SqlCommand comandoSelecao = new SqlCommand())
            {
                comandoSelecao.Connection = conexaoComBanco;

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SqlDataReader leitorCompromissos = comandoSelecao.ExecuteReader())
                {
                    if (leitorCompromissos.Read() == false) return null;


                    int id = Convert.ToInt32(leitorCompromissos["ID"]);
                    string assunto = (leitorCompromissos["ASSUNTO"]).ToString();
                    string local = (leitorCompromissos["LOCAL"]).ToString();
                    DateTime dataInicio = Convert.ToDateTime(leitorCompromissos["DATAINICIO"]);
                    DateTime dataFim = Convert.ToDateTime(leitorCompromissos["DATAFIM"]);
                    string linkReuniao = Convert.ToString(leitorCompromissos["LINKREUNIAO"]);

                    int idContato = 0;

                    if (leitorCompromissos["IDCONTATO"] != DBNull.Value)
                        idContato = Convert.ToInt32(leitorCompromissos["IDCONTATO"]);

                    string nomeContato = Convert.ToString(leitorCompromissos["NOME"]);
                    compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                             linkReuniao, idContato);

                    compromisso.nomeContato = nomeContato;

                    compromisso.id = id;
                }
            }
            conexaoComBanco.Close();
            return compromisso;
        }

        public List<Compromisso> SlecionarTodosSQLI(SQLiteConnection conexaoComBancoSQLite)
        {

            List<Compromisso> compromissos = new List<Compromisso>();


            AtivarChaveEstrangeira(conexaoComBancoSQLite);

            SQLiteCommand comandoSelecao = new SQLiteCommand();

            comandoSelecao.Connection = conexaoComBancoSQLite;


            comandoSelecao.CommandText = sqlSelecaoTodos;

            using (SQLiteDataReader leitorCompromissos = comandoSelecao.ExecuteReader())
            {
                while (leitorCompromissos.Read())
                {
                    int id = Convert.ToInt32(leitorCompromissos["ID"]);
                    string assunto = (leitorCompromissos["ASSUNTO"]).ToString();
                    string local = (leitorCompromissos["LOCAL"]).ToString();
                    DateTime dataInicio = Convert.ToDateTime(leitorCompromissos["DATAINICIO"]);
                    DateTime dataFim = Convert.ToDateTime(leitorCompromissos["DATAFIM"]);
                    string linkReuniao = Convert.ToString(leitorCompromissos["LINKREUNIAO"]);
                    int idContato = 0;
                    if (leitorCompromissos["IDCONTATO"] != DBNull.Value)
                        idContato = Convert.ToInt32(leitorCompromissos["IDCONTATO"]);

                    string nomeContato = Convert.ToString(leitorCompromissos["NOME"]);

                    Compromisso compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                             linkReuniao, idContato);

                    compromisso.nomeContato = nomeContato;
                    compromisso.id = id;

                    compromissos.Add(compromisso);

                }
            }
            conexaoComBancoSQLite.Close();
            return compromissos;
        }

        public List<Compromisso> SlecionarTodosSQLS(SqlConnection conexaoComBancoSQLite)
        {
            List<Compromisso> compromissos = new List<Compromisso>();
            

            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();


            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBancoSQLite;


            comandoSelecao.CommandText = sqlSelecaoTodos;

            using (SqlDataReader leitorCompromissos = comandoSelecao.ExecuteReader())
            {

                while (leitorCompromissos.Read())
                {
                    int id = Convert.ToInt32(leitorCompromissos["ID"]);
                    string assunto = (leitorCompromissos["ASSUNTO"]).ToString();
                    string local = (leitorCompromissos["LOCAL"]).ToString();
                    DateTime dataInicio = Convert.ToDateTime(leitorCompromissos["DATAINICIO"]);
                    DateTime dataFim = Convert.ToDateTime(leitorCompromissos["DATAFIM"]);
                    string linkReuniao = Convert.ToString(leitorCompromissos["LINKREUNIAO"]);
                    int idContato = 0;
                    if (leitorCompromissos["IDCONTATO"] != DBNull.Value)
                        idContato = Convert.ToInt32(leitorCompromissos["IDCONTATO"]);

                    string nomeContato = Convert.ToString(leitorCompromissos["NOME"]);

                    Compromisso compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                             linkReuniao, idContato);

                    compromisso.nomeContato = nomeContato;
                    compromisso.id = id;

                    compromissos.Add(compromisso);
                }

            }
            conexaoComBancoSQLite.Close();
            return compromissos;
        }

        public void ExcluirComSQLI(int id, SQLiteConnection conexaoComBancoSQLite)
        {
            AtivarChaveEstrangeira(conexaoComBancoSQLite);

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
    }
}
