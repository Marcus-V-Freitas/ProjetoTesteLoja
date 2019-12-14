using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.BLL.Entidades;
using DLL.BLL.Enums;

namespace DLL.BLL.Validacoes.Desconto
{
    public class CartaoDesconto : AbstractDesconto
    {
        public override void  Descontar(Venda venda)
        {
            if (venda.FormaPagamento.Equals(FormaPagamento.CartaoCredito))
            {
                venda.ValorTotal -= (venda.ValorTotal * 0.1);
            }
            else
            {
                if (_abstractDesconto != null)
                    _abstractDesconto.Descontar(venda);
            }
        }
    }
}
