using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
    public partial class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public UnidadeMedida UnidadeMedida { get; set; }

        public int Estoque { get; set; }

        public double PrecoUnitario { get; set; }

        public string Descricao { get; set; }



    }

    public partial class Produto
    {
        public Produto() { }

        public Produto(string nome, UnidadeMedida unidadeMedida, int estoque, double precoUnitario, string descricao)
        {
            Nome = nome;
            UnidadeMedida = unidadeMedida;
            Estoque = estoque;
            PrecoUnitario = precoUnitario;
            Descricao = descricao;
        }
    }


}
