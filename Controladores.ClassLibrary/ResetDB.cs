using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary
{
    public class ResetDB
    {
        protected static readonly string connectionStringDBSQLI = ConfigurationManager.ConnectionStrings["DBeAgendaSQLI"].ConnectionString;
        protected static readonly string connectionStringDBSQLS = ConfigurationManager.ConnectionStrings["DBeAgendaSQLS"].ConnectionString;

        protected SQLiteConnection conexaoBancoSQLI = new SQLiteConnection(connectionStringDBSQLI);
        private SqlConnection conexaoBancoSQLS = new SqlConnection(connectionStringDBSQLS);

        public void DeleteSQLI(string delete)
        {
            conexaoBancoSQLI.Close();
            conexaoBancoSQLI.Open();

            SQLiteCommand comandoDelete = new SQLiteCommand();

            comandoDelete.Connection = conexaoBancoSQLI;

            string sqlDelete = delete;

            comandoDelete.CommandText = sqlDelete;

            comandoDelete.ExecuteNonQuery();

            conexaoBancoSQLI.Close();
        }

        public void DeleteSQLS(string delete)
        {
            conexaoBancoSQLS.Close();
            conexaoBancoSQLS.Open();

            SqlCommand comandoDelete = new SqlCommand();

            comandoDelete.Connection = conexaoBancoSQLS;

            string sqlDelete = delete;

            comandoDelete.CommandText = sqlDelete;

            comandoDelete.ExecuteNonQuery();

            conexaoBancoSQLS.Close();
        }
    }
}
