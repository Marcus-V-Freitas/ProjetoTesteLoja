using DLL.BLL.Validacoes.CPFCNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
   public partial class ClienteJuridico:Cliente
    {
        private static readonly CNPJ validar = new CNPJ(new CalculoCPFCNPJ());

        public string CNPJ { get; set; }

    }


    public partial class ClienteJuridico
    {
        public ClienteJuridico(string nome, string email,DateTime nascimento, string cnpj) : base(nome, email, nascimento)
        {

            CNPJ = (validar.ValidarCNPJ(cnpj)) ? cnpj : throw new Exception("CNPJ Errado");
        }

        public ClienteJuridico() { }
    }
}
