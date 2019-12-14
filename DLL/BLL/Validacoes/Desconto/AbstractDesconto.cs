using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.Desconto
{
   
   public abstract class AbstractDesconto
    {
        protected AbstractDesconto _abstractDesconto;

        public abstract void Descontar(Venda venda);

        public void setSucessor(AbstractDesconto abstractDesconto)
        {
            _abstractDesconto = abstractDesconto;
        }

      
    }
}
