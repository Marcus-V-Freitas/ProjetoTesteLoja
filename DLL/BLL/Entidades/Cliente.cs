using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
   public abstract partial class Cliente
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }
     
    }

    public abstract partial class Cliente
    {
        public Cliente() { }


        public Cliente(string nome, string email,DateTime nascimento)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
        }
    }
}
