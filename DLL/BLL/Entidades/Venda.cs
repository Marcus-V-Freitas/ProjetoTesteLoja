using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Entidades
{
    public partial class Venda
    {
        public int? Codigo { get; set; }

        public double ValorTotal { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public DateTime DataCompra { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<ProdutosVenda> ProdutosVendas { get; set; }

        public StatusVenda StatusVenda { get; set; }
    }


    public partial class Venda
    {
        public Venda() { StatusVenda = StatusVenda.Pendente; }

        public Venda(double valorTotal, FormaPagamento formaPagamento, Cliente cliente, List<ProdutosVenda> produtosVendas)
        {
            StatusVenda = StatusVenda.Pendente;
            ValorTotal = valorTotal;
            FormaPagamento = formaPagamento;
            Cliente = cliente;
            ProdutosVendas = produtosVendas;
        }
    }
}
