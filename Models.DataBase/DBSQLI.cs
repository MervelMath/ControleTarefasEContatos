using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    public class DBSQLI<T> where T : EntidadeBase
    {
        public override List<Tarefa> SelecionarTodosRegistros()
        {
            conexaoComBancoSQLite.Close();
            conexaoComBancoSQLite.Open();


            SQLiteCommand comandoSelecao = new SQLiteCommand();

            comandoSelecao.Connection = conexaoComBancoSQLite;

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
    }
}
