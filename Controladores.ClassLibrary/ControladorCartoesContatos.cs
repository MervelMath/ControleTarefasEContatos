using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary
{
    public class ControladorCartoesContatos : ControladorBase<CartoesDeContatos>
    {
        public override CartoesDeContatos SelecionarRegistroPorId(int idPesquisado)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

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


            comandoSelecao.CommandText = sqlSelecao;

            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorCartoes = comandoSelecao.ExecuteReader();


            if (leitorCartoes.Read() == false) return null;

            int id = Convert.ToInt32(leitorCartoes["ID"]);
            string nome = (leitorCartoes["NOME"]).ToString();
            string email = (leitorCartoes["EMAIL"]).ToString();
            int telefone = Convert.ToInt32(leitorCartoes["TELEFONE"]);
            string empresa = Convert.ToString(leitorCartoes["EMPRESA"]);
            string cargo = Convert.ToString(leitorCartoes["CARGO"]);

            CartoesDeContatos cartao = new CartoesDeContatos(nome, email, telefone,
                    empresa, cargo);

            cartao.id = id;

            conexaoComBanco.Close();

            return cartao;
        }

        public override List<CartoesDeContatos> SelecionarTodosRegistros()
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"
                SELECT 
	            	[ID],
	            	[NOME],
	            	[EMAIL], 
	            	[TELEFONE], 
	            	[EMPRESA], 
	            	[CARGO]
	            FROM TBCARTOES";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorCartoes = comandoSelecao.ExecuteReader();

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

            conexaoComBanco.Close();

            return cartoes;
        }

        public override void Editar(CartoesDeContatos obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoEdicao = new SqlCommand();

            comandoEdicao.Connection = conexaoComBanco;

            string sqlEdicao =
                @"UPDATE TBCARTOES 
		                SET
		                	[NOME] = @NOME,
		                	[EMAIL] = @EMAIL,
		                	[TELEFONE] = @TELEFONE,
		                	[EMPRESA] = @EMPRESA,
		                	[CARGO] = @CARGO
		                 WHERE
		                    [ID] = @ID";

            comandoEdicao.CommandText = sqlEdicao;


            comandoEdicao.Parameters.AddWithValue("ID", obj.id);
            comandoEdicao.Parameters.AddWithValue("NOME", obj.nome);
            comandoEdicao.Parameters.AddWithValue("EMAIL", obj.email);
            comandoEdicao.Parameters.AddWithValue("TELEFONE", obj.telefone);
            comandoEdicao.Parameters.AddWithValue("EMPRESA", obj.empresa);
            comandoEdicao.Parameters.AddWithValue("CARGO", obj.cargo);

            comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public override void Excluir(int id)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoExcluir = new SqlCommand();

            comandoExcluir.Connection = conexaoComBanco;

            string sqlExclusao =
                @"DELETE FROM TBCARTOES 
		                 WHERE
		                    [ID] = @ID";

            comandoExcluir.CommandText = sqlExclusao;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public override void Inserir(CartoesDeContatos obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
                @"INSERT INTO TBCARTOES
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
                		)";
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
    }
}
