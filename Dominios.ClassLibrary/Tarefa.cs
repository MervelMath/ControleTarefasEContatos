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
                    return "Prioridade inválida!";

                return "VALIDA";
            }

        public override bool Equals(object obj)
        {
            return obj is Tarefa tarefa &&
                   id == tarefa.id &&
                   prioridade == tarefa.prioridade &&
                   titulo == tarefa.titulo &&
                   dataCriacao == tarefa.dataCriacao &&
                   dataConclusao == tarefa.dataConclusao &&
                   percentual == tarefa.percentual;
        }

        public override int GetHashCode()
        {
            int hashCode = -1525883055;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + prioridade.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(titulo);
            hashCode = hashCode * -1521134295 + dataCriacao.GetHashCode();
            hashCode = hashCode * -1521134295 + dataConclusao.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(percentual);
            return hashCode;
        }

        public override string ToString()
        {
            return titulo;
        }
    }
    }

