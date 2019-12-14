using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.Desconto
{
    public class DinheiroDesconto : AbstractDesconto
    {
        public override void Descontar(Venda venda)
        {
            if (venda.FormaPagamento.Equals(FormaPagamento.Dinheiro))
            {
                venda.ValorTotal -= (venda.ValorTotal * 0.15);
            }
            else
            {
                if(_abstractDesconto!=null)
                _abstractDesconto.Descontar(venda);
            }
        }
    }
}
