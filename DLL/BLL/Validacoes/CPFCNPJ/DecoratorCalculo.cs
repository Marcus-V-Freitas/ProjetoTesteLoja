using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ
{
    public class DecoratorCalculo : AbstractCalculo
    {

        protected static AbstractCalculo _abstractCalculo;


        public DecoratorCalculo(AbstractCalculo abstractCalculo)
        {
            _abstractCalculo = abstractCalculo;
        }


        public override int CalcularDigitos(string strings, int[] tamanho)
        {
           return _abstractCalculo.CalcularDigitos(strings, tamanho);
        }
    }
}
