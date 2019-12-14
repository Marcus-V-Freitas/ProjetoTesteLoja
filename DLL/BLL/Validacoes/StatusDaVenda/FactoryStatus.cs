using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.StatusDaVenda
{
    public class FactoryStatus
    {
        private Hashtable status = new Hashtable();

        public FactoryStatus()
        {
            status.Add(FormaPagamento.Boleto, new StatusPendente());
            status.Add(FormaPagamento.Dinheiro, new StatusPendente());
            status.Add(FormaPagamento.CartaoCredito, new StatusAprovado());
            status.Add("cancela", new StatusRejeitado());
        }

        public StatusVenda GetStatus(Venda venda)
        {
            if (venda!=null){
                return ((AbstractStatus)status[venda.FormaPagamento]).AlterarStatus(venda);
            }
            else
            {
                return ((AbstractStatus)status["cancela"]).AlterarStatus(new Venda());
            }
        }
    }
}
