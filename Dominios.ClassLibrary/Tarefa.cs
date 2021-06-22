using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.ClassLibrary
{
        public class Tarefa : EntidadeBase
        {

            public int prioridade;
            public string titulo;
            public DateTime dataCriacao;
            public DateTime dataConclusao;
            public string percentual;

            public Tarefa(int prioridade, string titulo, DateTime dataCriacao, DateTime dataConclusao, string percentual)
            {
                this.prioridade = prioridade;
                this.titulo = titulo;
                this.dataCriacao = dataCriacao;
                this.dataConclusao = dataConclusao;
                this.percentual = percentual;
            }

            public override string Validar()
            {
                int comparacaoDeDatas = DateTime.Compare(dataCriacao, dataConclusao);

                if (comparacaoDeDatas > 0)
                    return "A data de conclusão não pode ser menor que a atual.";

                else if (prioridade > 2 || prioridade < 0)
                    return "Prioridade inválida";

                return "VALIDA";
            }
        }
    }

