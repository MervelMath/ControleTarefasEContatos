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
            if (email.Substring(email.Length - 4) != ".com")
                return ("O email não contém o finalizador '.com'!");

            if(email.Contains("@") == false)
                return ("O email não contém um domínio com '@'.");

            if (telefone.ToString().Length < 6)
                return ("O número de telefone é muito pequeno.");

            return "VALIDA";
        }
    }
}
