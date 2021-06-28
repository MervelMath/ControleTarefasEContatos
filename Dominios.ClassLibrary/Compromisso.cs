using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.ClassLibrary
{
    public class Compromisso : EntidadeBase
    {
        private string assunto;
        private string local;
        private DateTime dataInicioCompromisso;
        private DateTime dataTerminoCompromisso;
        private string linkReuniao;
        public int idContato;
        public string nomeContato;

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime dataTerminoCompromisso, string linkReuniao, int idContato)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataInicioCompromisso = dataCompromisso;
            this.idContato = idContato;
            this.linkReuniao = linkReuniao;
            this.dataTerminoCompromisso = dataTerminoCompromisso;
        }

        public string Assunto { get => assunto; set => assunto = value; }
        public string Local { get => local;}
        public DateTime DataInicio { get => dataInicioCompromisso;}
        public string LinkReuniao { get => linkReuniao; set => linkReuniao = value; }
        public DateTime DataTerminoCompromisso { get => dataTerminoCompromisso;}

        public override string Validar()
        {
            int comparacaoDeDatasHoje = DateTime.Compare(dataInicioCompromisso, DateTime.Now);

            if (comparacaoDeDatasHoje < 0)
                return "A data do compromisso não pode ser menor que a atual.";

            int comparacaoDeDatasInicioFim = DateTime.Compare(dataInicioCompromisso, dataTerminoCompromisso);

            if (comparacaoDeDatasInicioFim >= 0)
                return "A data de início do compromisso não pode ser menor que a data de término.";

            return "VALIDA";
        }
    }
}
