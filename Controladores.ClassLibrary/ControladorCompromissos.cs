using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Controladores.ClassLibrary
{
    public class ControladorCompromissos : ControladorBase<Compromisso>
    {
        public override Compromisso SelecionarRegistroPorId(int idPesquisado)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

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


            comandoSelecao.CommandText = sqlSelecao;

            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorCompromissos = comandoSelecao.ExecuteReader();


            if (leitorCompromissos.Read() == false) return null;

            int id, idContato;
            string assunto, local, linkReuniao, nomeContato;
            DateTime dataInicio;
            DateTime dataFim;
            SelecionarCompromisso(leitorCompromissos, out id, out assunto, out local,
                out dataInicio, out dataFim, out linkReuniao, out idContato, out nomeContato);

            Compromisso compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                     linkReuniao, idContato);

            compromisso.nomeContato = nomeContato;

            compromisso.id = id;

            conexaoComBanco.Close();

            return compromisso;
        }

        public override List<Compromisso> SelecionarTodosRegistros()
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoSelecao = new SqlCommand();

            comandoSelecao.Connection = conexaoComBanco;

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
	            	CP.IDCONTATO = CR.ID";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorCompromissos = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromissos.Read())
            {
                int id, idContato;
                string assunto, local, linkReuniao, nomeContato;
                DateTime dataInicio;
                DateTime dataFim;
                SelecionarCompromisso(leitorCompromissos, out id, out assunto, out local,
                    out dataInicio, out dataFim, out linkReuniao, out idContato, out nomeContato);

                Compromisso compromisso = new Compromisso(assunto, local, dataInicio, dataFim,
                         linkReuniao, idContato);

                compromisso.nomeContato = nomeContato;
                compromisso.id = id;

                compromissos.Add(compromisso);
            }

            conexaoComBanco.Close();

            return compromissos;
        }


        public override void Editar(Compromisso obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoEdicao = new SqlCommand();

            comandoEdicao.Connection = conexaoComBanco;

            string sqlEdicao =
                @"UPDATE TBCOMPROMISSOS 
		             SET
		             	[ASSUNTO] = @ASSUNTO,
		             	[LOCAL] = @LOCAL,
		             	[DATAINICIO] = @DATAINICIO,
		             	[LINKREUNIAO] = @LINKREUNIAO,
		             	[IDCONTATO] = @IDCONTATO,
                        [DATAFIM] = @DATAFIM
		             WHERE
		             	[ID] = @ID";

            comandoEdicao.CommandText = sqlEdicao;

            AdicionarCompromissoAoBanco(obj, comandoEdicao);

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
                @"DELETE FROM TBCOMPROMISSOS 
		                 WHERE
		                    [ID] = @ID";

            comandoExcluir.CommandText = sqlExclusao;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public override void Inserir(Compromisso obj)
        {
            conexaoComBanco.Close();
            conexaoComBanco.Open();


            SqlCommand comandoInsercao = new SqlCommand();

            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
                @"insert into TBCOMPROMISSOS
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
                		)";
            sqlInsercao +=
                @"select SCOPE_IDENTITY()";

            comandoInsercao.CommandText = sqlInsercao;
            AdicionarCompromissoAoBanco(obj, comandoInsercao);

            object id = comandoInsercao.ExecuteScalar();
            obj.id = Convert.ToInt32(id);
            conexaoComBanco.Close();
        }

        private static void AdicionarCompromissoAoBanco(Compromisso obj, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", obj.id);
            comando.Parameters.AddWithValue("ASSUNTO", obj.Assunto);
            comando.Parameters.AddWithValue("LOCAL", obj.Local);
            comando.Parameters.AddWithValue("DATAINICIO", obj.DataInicio);
            comando.Parameters.AddWithValue("DATAFIM", obj.DataTerminoCompromisso);
            comando.Parameters.AddWithValue("LINKREUNIAO", obj.LinkReuniao);
            if (obj.idContato == 0)
                comando.Parameters.AddWithValue("IDCONTATO", DBNull.Value);
            else
                comando.Parameters.AddWithValue("IDCONTATO", obj.idContato);
        }

        private static void SelecionarCompromisso(SqlDataReader leitorCompromissos, out int id, out string assunto,
            out string local, out DateTime dataInicio, out DateTime dataFim,
            out string linkReuniao, out int idContato, out string nomeContato)
        {
            id = Convert.ToInt32(leitorCompromissos["ID"]);
            assunto = (leitorCompromissos["ASSUNTO"]).ToString();
            local = (leitorCompromissos["LOCAL"]).ToString();
            dataInicio = Convert.ToDateTime(leitorCompromissos["DATAINICIO"]);
            dataFim = Convert.ToDateTime(leitorCompromissos["DATAFIM"]);
            linkReuniao = Convert.ToString(leitorCompromissos["LINKREUNIAO"]);
            idContato = 0;
            idContato = VerificarEinserifIdContato(leitorCompromissos, idContato);

            nomeContato = Convert.ToString(leitorCompromissos["NOME"]);
        }

        private static int VerificarEinserifIdContato(SqlDataReader leitorCompromissos, int idContato)
        {
            if (leitorCompromissos["IDCONTATO"] != DBNull.Value)
                idContato = Convert.ToInt32(leitorCompromissos["IDCONTATO"]);
            return idContato;
        }

    }
}
