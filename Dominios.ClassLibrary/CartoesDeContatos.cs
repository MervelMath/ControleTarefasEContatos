using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.ClassLibrary
{
    public class CartoesDeContatos : EntidadeBase
    {
        /*Desta forma, para cada contato, José Pedro gostaria de armazenar o nome,
         * e-mail, telefone, empresa e o cargo da pessoa e claro ele terá
         * a possibilidade de registrar novos contatos, visualizar, editar e excluir contatos existentes;*/

        public string nome = "";
        public string email = "";
        public int telefone = 0;
        public string empresa = "";
        public string cargo = "";

        public CartoesDeContatos(string nome, string email, int telefone, string empresa, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargo = cargo;
        }


        public override string Validar()
        {
            if (email.Length >= 4)
            {
                if (email.Substring(email.Length - 4) != ".com")
                    return ("O email não contém o finalizador '.com'!");
            }
            if(email.Contains("@") == false)
                return ("O email não contém um domínio com '@'.");

            if (telefone.ToString().Length < 6)
                return ("O número de telefone é muito pequeno.");

            return "VALIDA";
        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            return obj is CartoesDeContatos contatos &&
                   id == contatos.id &&
                   nome == contatos.nome &&
                   email == contatos.email &&
                   telefone == contatos.telefone &&
                   empresa == contatos.empresa &&
                   cargo == contatos.cargo;
        }

        public override int GetHashCode()
        {
            int hashCode = -360649799;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + telefone.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(empresa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cargo);
            return hashCode;
        }
    }
}
