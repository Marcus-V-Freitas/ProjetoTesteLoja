using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Enums
{
    //Formas de Pagamento aceitas pelo sistemas
    public enum FormaPagamento:int
    {
        Boleto=1,
        CartaoCredito=2,
        Dinheiro=3
    }
}
