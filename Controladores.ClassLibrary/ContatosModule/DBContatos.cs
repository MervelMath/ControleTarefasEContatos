using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary.ContatosModule
{
    public class DBContatos
    {
        #region
        string sqlInsercao =
                @"PRAGMA foreign_keys = ON;
                    INSERT INTO TBCARTOES
                		(
		                [NOME],
		                [EMAIL], 
		                [TELEFONE], 
		                [EMPRESA], 
		                [CARGO]
		                )
                
                VALUES
                		(
                		@NOME, 
                		@EMAIL, 
                		@TELEFONE, 
                		@EMPRESA,
                        @CARGO
                		);";

        string sqlSelecaoTodos =
                @"PRAGMA foreign_keys = ON;
                SELECT 
	            	[ID],
	            	[NOME],
	            	[EMAIL], 
	            	[TELEFONE], 
	            	[EMPRESA], 
	            	[CARGO]
	            FROM TBCARTOES";

        string sqlEdicao =
                @"PRAGMA foreign_keys = ON;
                    UPDATE TBCARTOES 
		                SET
		                	[NOME] = @NOME,
		                	[EMAIL] = @EMAIL,
		                	[TELEFONE] = @TELEFONE,
		                	[EMPRESA] = @EMPRESA,
		                	[CARGO] = @CARGO
		                 WHERE
		                    [ID] = @ID";

        string sqlExclusao =
                @"DELETE FROM TBCARTOES 
		                 WHERE
		                    [ID] = @ID";

        string sqlSelecao =
                @"
                SELECT 
	               	[ID],
	               	[NOME],
	               	[EMAIL], 
	               	[TELEFONE], 
	               	[EMPRESA], 
	               	[CARGO]
	            FROM 
                    TBCARTOES
                ORDER BY
		            [CARGO]";

        #endregion

        public void AtivarChaveEstrangeira(SQLiteConnection conexaoComBancoSQLite)
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();

            SQLiteCommand comando = new SQLiteCommand();

            comando.CommandText = "PRAGMA foreign_keys=ON;";

            comando.Connection = conexaoComBancoSQLite;

            comando.ExecuteNonQuery();
        }

        public void InserirSQLI(CartoesDeContatos obj, SQLiteConnection conexaoComBancoSQLite)
        {
            AtivarChaveEstrangeira(conexaoComBancoSQLite);

            SQLiteCommand comandoInsercao = new SQLiteCommand();

            comandoInsercao.Connection = conexaoComBancoSQLite;

            
            sqlInsercao +=
                @"SELECT LAST_INSERT_ROWID();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("NOME", obj.nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", obj.email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", obj.telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", obj.empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", obj.cargo);


            object id = comandoInsercao.ExecuteScalar();

            obj.id = Convert.ToInt32(id);
            conexaoComBancoSQLite.Close();
        }

        public void InserirSQLS(CartoesDeContatos obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

            sqlInsercao +=
                @"select SCOPE_IDENTITY()";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("NOME", obj.nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", obj.email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", obj.telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", obj.empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", obj.cargo);

            object id = comandoInsercao.ExecuteScalar();

            obj.id = Convert.ToInt32(id);
            conexaoComBanco.Close();
        }

        public List<CartoesDeContatos> SlecionarTodosSQLI(SQLiteConnection conexaoComBancoSQLite)
        {
            AtivarChaveEstrangeira(conexaoComBancoSQLite);


            SQLiteCommand comandoSelecao = new SQLiteCommand();

            comandoSelecao.Connection = conexaoComBancoSQLite;


            comandoSelecao.CommandText = sqlSelecaoTodos;

            SQLiteDataReader leitorCartoes = comandoSelecao.ExecuteReader();

            List<CartoesDeContatos> cartoes = new List<CartoesDeContatos>();

           
                while (leitorCartoes.Read())
                {
                    int id = Convert.ToInt32(leitorCartoes["ID"]);
                    string nome = (leitorCartoes["NOME"]).ToString();
                    string email = (leitorCartoes["EMAIL"]).ToString();
                    int telefone = Convert.ToInt32(leitorCartoes["TELEFONE"]);
                    string empresa = Convert.ToString(leitorCartoes["EMPRESA"]);
                    string cargo = Convert.ToString(leitorCartoes["CARGO"]);

                    CartoesDeContatos cartao = new CartoesDeContatos(nome, email, telefone,
                        empresa, cargo);

                    cartao.id = id;

                    cartoes.Add(cartao);

                }

            conexaoComBancoSQLite.Close();
            return cartoes;
        }

        public List<CartoesDeContatos> SlecionarTodosSQLS(SqlConnection conexaoComBanco)
        {

            List<CartoesDeContatos> cartoes = new List<CartoesDeContatos>();

            conexaoComBanco.Close();
            conexaoComBanco.Open();

            using (SqlCommand comandoSelecao = new SqlCommand())
            {

                comandoSelecao.Connection = conexaoComBanco;


                comandoSelecao.CommandText = sqlSelecaoTodos;

                using (SqlDataReader laietorCartoes = comandoSelecao.ExecuteReader())
                {


                    while (laietorCartoes.Read())
                    {
                        int id = Convert.ToInt32(laietorCartoes["ID"]);
                        string nome = (laietorCartoes["NOME"]).ToString();
                        string email = (laietorCartoes["EMAIL"]).ToString();
                        int telefone = Convert.ToInt32(laietorCartoes["TELEFONE"]);
                        string empresa = Convert.ToString(laietorCartoes["EMPRESA"]);
                        string cargo = Convert.ToString(laietorCartoes["CARGO"]);

                        CartoesDeContatos cartao = new CartoesDeContatos(nome, email, telefone,
                            empresa, cargo);

                        cartao.id = id;

                        cartoes.Add(cartao);

                    }
                }
            }
            conexaoComBanco.Close();
            return cartoes;
        }

        public void EditarComSQLI(CartoesDeContatos obj, SQLiteConnection conexaoComBancoSQLite)
        {
            
            AtivarChaveEstrangeira(conexaoComBancoSQLite);


            using (SQLiteCommand comandoEdicao = new SQLiteCommand())
            {

                comandoEdicao.Connection = conexaoComBancoSQLite;

                

                comandoEdicao.CommandText = sqlEdicao;


                comandoEdicao.Parameters.AddWithValue("ID", obj.id);
                comandoEdicao.Parameters.AddWithValue("NOME", obj.nome);
                comandoEdicao.Parameters.AddWithValue("EMAIL", obj.email);
                comandoEdicao.Parameters.AddWithValue("TELEFONE", obj.telefone);
                comandoEdicao.Parameters.AddWithValue("EMPRESA", obj.empresa);
                comandoEdicao.Parameters.AddWithValue("CARGO", obj.cargo);

                comandoEdicao.ExecuteNonQuery();
            }
            conexaoComBancoSQLite.Close();
        }

        public void EditarComSQLS(CartoesDeContatos obj, SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            using (SqlCommand comandoEdicao = new SqlCommand())
            {

                comandoEdicao.Connection = conexaoComBanco;

                comandoEdicao.CommandText = sqlEdicao;


                comandoEdicao.Parameters.AddWithValue("ID", obj.id);
                comandoEdicao.Parameters.AddWithValue("NOME", obj.nome);
                comandoEdicao.Parameters.AddWithValue("EMAIL", obj.email);
                comandoEdicao.Parameters.AddWithValue("TELEFONE", obj.telefone);
                comandoEdicao.Parameters.AddWithValue("EMPRESA", obj.empresa);
                comandoEdicao.Parameters.AddWithValue("CARGO", obj.cargo);

                comandoEdicao.ExecuteNonQuery();
            }
            conexaoComBanco.Close();
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

        public CartoesDeContatos SelecionarPorIdComSQLI(int idPesquisado, SQLiteConnection conexaoComBancoSQLite)
        {
            CartoesDeContatos cartao;
            AtivarChaveEstrangeira(conexaoComBancoSQLite);

            using (SQLiteCommand comandoSelecao = new SQLiteCommand())
            {
                comandoSelecao.Connection = conexaoComBancoSQLite;

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SQLiteDataReader leitorCartoes = comandoSelecao.ExecuteReader())
                {
                    if (leitorCartoes.Read() == false) return null;

                    int id = Convert.ToInt32(leitorCartoes["ID"]);
                    string nome = (leitorCartoes["NOME"]).ToString();
                    string email = (leitorCartoes["EMAIL"]).ToString();
                    int telefone = Convert.ToInt32(leitorCartoes["TELEFONE"]);
                    string empresa = Convert.ToString(leitorCartoes["EMPRESA"]);
                    string cargo = Convert.ToString(leitorCartoes["CARGO"]);

                    cartao = new CartoesDeContatos(nome, email, telefone,
                            empresa, cargo);
                    cartao.id = id;
                }
            }
            conexaoComBancoSQLite.Close();
            return cartao;
        }

        public CartoesDeContatos SelecionarPorIdComSQLS(int idPesquisado, SqlConnection conexaoComBanco)
        {
            CartoesDeContatos cartao;
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            using (SqlCommand comandoSelecao = new SqlCommand())
            {
                comandoSelecao.Connection = conexaoComBanco;

                comandoSelecao.CommandText = sqlSelecao;

                comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

                using (SqlDataReader leitorCartoes = comandoSelecao.ExecuteReader())
                {
                    if (leitorCartoes.Read() == false) return null;

                    int id = Convert.ToInt32(leitorCartoes["ID"]);
                    string nome = (leitorCartoes["NOME"]).ToString();
                    string email = (leitorCartoes["EMAIL"]).ToString();
                    int telefone = Convert.ToInt32(leitorCartoes["TELEFONE"]);
                    string empresa = Convert.ToString(leitorCartoes["EMPRESA"]);
                    string cargo = Convert.ToString(leitorCartoes["CARGO"]);

                    cartao = new CartoesDeContatos(nome, email, telefone,
                            empresa, cargo);
                    cartao.id = id;
                }
            }
            conexaoComBanco.Close();
            return cartao;
        }
    }
}
