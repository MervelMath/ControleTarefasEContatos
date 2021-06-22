using Dominios.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.ClassLibrary
{
    public abstract class ControladorBase<T> where T : EntidadeBase
    {

        private static string enderecoDB =
                             @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DBTarefas;Integrated Security=True;Pooling=False";
        protected SqlConnection conexaoComBanco = new SqlConnection(enderecoDB);


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
