using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
    public partial class ProdutosVenda
    {
        public int? CodigoVenda { get; set; }

        public int? CodigoProduto { get; set; }

        public int Quantidade { get; set; }

        public double PrecoUnitario { get; set; }
    }

    public partial class ProdutosVenda
    {
        public ProdutosVenda(int codigoProduto,int quantidade, double precoUnitario)
        {
            CodigoProduto = codigoProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }
}
