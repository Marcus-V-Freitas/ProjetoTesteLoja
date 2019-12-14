using DLL.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLL.BLL.Validacoes.Desconto
{
    public static class Desconto
    {
        private static List<AbstractDesconto> descontos = new List<AbstractDesconto>();

        public static void Descontar(this Venda venda){
 
            descontos.Add(new CartaoDesconto());
            descontos.Add(new BoletoDesconto());
            descontos.Add(new DinheiroDesconto());

            int i = 1;
            foreach (var item in descontos)
            {
                if (!i.Equals(descontos.Count))
                {
                    item.setSucessor(descontos[i]);
                    i++;
                }

            }

            descontos[0].Descontar(venda);
        }
    }
}
