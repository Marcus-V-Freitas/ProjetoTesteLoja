using DLL.BLL.Validacoes.CPFCNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
    public partial class ClienteFisico:Cliente
    {
       private static readonly CPF validar = new CPF(new CalculoCPFCNPJ());

        public string CPF { get; set; }

    }

    public partial class ClienteFisico
    {
        public ClienteFisico(string nome, string email,DateTime nascimento, string cpf) : base(nome, email,nascimento)
        {
            
            CPF= (validar.ValidarCPF(cpf))?cpf: throw new Exception("CPF errado");
          

        }

        public ClienteFisico() { }
    }
}
