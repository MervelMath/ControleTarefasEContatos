using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary
{
    public class ControladorTarefa : ControladorBase<Tarefa>
    {
        public override List<Tarefa> SelecionarTodosRegistros()
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

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
                    ORDER BY
		                 [PRIORIDADE] DESC";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

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

            conexaoComBanco.Close();

            return tarefas;
        }

        public override void Editar(Tarefa obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoEdicao = new SqlCommand();

            comandoEdicao.Connection = conexaoComBanco;

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

            comandoEdicao.CommandText = sqlEdicao;


            comandoEdicao.Parameters.AddWithValue("ID", obj.id);
            comandoEdicao.Parameters.AddWithValue("TITULO", obj.titulo);
            comandoEdicao.Parameters.AddWithValue("DATACRIACAO", obj.dataCriacao);
            comandoEdicao.Parameters.AddWithValue("DATACONCLUSAO", obj.dataConclusao);
            comandoEdicao.Parameters.AddWithValue("PERCENTUAL", obj.percentual);
            comandoEdicao.Parameters.AddWithValue("PRIORIDADE", obj.prioridade);

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
                @"DELETE FROM TBTAREFAS 
		                 WHERE
		                    [ID] = @ID";

            comandoExcluir.CommandText = sqlExclusao;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public override void Inserir(Tarefa obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

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
                		)";
            sqlInsercao +=
                @"select SCOPE_IDENTITY()";

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

        public override Tarefa SelecionarRegistroPorId(int idPesquisado)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

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


            comandoSelecao.CommandText = sqlSelecao;

            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();


            if (leitorTarefas.Read() == false) return null;

            int id = Convert.ToInt32(leitorTarefas["ID"]);
            string titulo = (leitorTarefas["TITULO"]).ToString();
            DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
            DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
            string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
            int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

            Tarefa tarefa = new Tarefa(prioridade, titulo, dataCriacao, dataConclusao, percentual);

            tarefa.id = id;

            conexaoComBanco.Close();

            return tarefa;
        }

    }
}
