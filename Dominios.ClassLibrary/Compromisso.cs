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

        public Compromisso(string assunto, string local, DateTime dataCompromisso,
            DateTime dataTerminoCompromisso, string linkReuniao, int idContato)
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
            if (linkReuniao.Substring(linkReuniao.Length - 4) != ".com")
                return ("O link não contém o finalizador '.com'!");

            int comparacaoDeDatasHoje = DateTime.Compare(dataInicioCompromisso, DateTime.Now);

            if (comparacaoDeDatasHoje < 0)
                return "A data do compromisso não pode ser menor que a atual.";

            int comparacaoDeDatasInicioFim = DateTime.Compare(dataInicioCompromisso, dataTerminoCompromisso);

            if (comparacaoDeDatasInicioFim >= 0)
                return "A data de início do compromisso não pode ser menor que a data de término.";

            return "VALIDA";
        }

        public override bool Equals(object obj)
        {
            return obj is Compromisso compromisso &&
                   id == compromisso.id &&
                   assunto == compromisso.assunto &&
                   local == compromisso.local &&
                   dataInicioCompromisso == compromisso.dataInicioCompromisso &&
                   dataTerminoCompromisso == compromisso.dataTerminoCompromisso &&
                   linkReuniao == compromisso.linkReuniao &&
                   idContato == compromisso.idContato &&
                   nomeContato == compromisso.nomeContato &&
                   Assunto == compromisso.Assunto &&
                   Local == compromisso.Local &&
                   DataInicio == compromisso.DataInicio &&
                   LinkReuniao == compromisso.LinkReuniao &&
                   DataTerminoCompromisso == compromisso.DataTerminoCompromisso;
        }

        public override int GetHashCode()
        {
            int hashCode = -1182057499;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(assunto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(local);
            hashCode = hashCode * -1521134295 + dataInicioCompromisso.GetHashCode();
            hashCode = hashCode * -1521134295 + dataTerminoCompromisso.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(linkReuniao);
            hashCode = hashCode * -1521134295 + idContato.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nomeContato);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Assunto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Local);
            hashCode = hashCode * -1521134295 + DataInicio.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LinkReuniao);
            hashCode = hashCode * -1521134295 + DataTerminoCompromisso.GetHashCode();
            return hashCode;
        }
    }
}
