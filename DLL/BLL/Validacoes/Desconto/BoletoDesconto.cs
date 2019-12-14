using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.Desconto
{
   public class BoletoDesconto:AbstractDesconto
    {
        public override void Descontar(Venda venda)
        {
            if (venda.FormaPagamento.Equals(FormaPagamento.Boleto))
            {
                venda.ValorTotal -= (venda.ValorTotal * 0.05);
            }
            else
            {
                if (_abstractDesconto != null)
                    _abstractDesconto.Descontar(venda);
            }
        }
    }
}
