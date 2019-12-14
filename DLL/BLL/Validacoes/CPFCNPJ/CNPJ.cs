using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ
{
    public class CNPJ : DecoratorCalculo
    {
        //Numeros para multiplos do CNPJ
        private static readonly int[] multiplosCNPJ = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public CNPJ(AbstractCalculo abstractCalculo) : base(abstractCalculo)
        {
        }

        public bool ValidarCNPJ(string cnpj)
        {
            if (cnpj == null)
            {
                return false;
            }

            //Expressão regular para retirar quaisquer dados que não sejam números
            var apenasDigitos = new Regex(@"[^\d]");
            cnpj = apenasDigitos.Replace((string)cnpj, "");

            if ((cnpj.Length == 14))
            {
                int digito1 = CalcularDigitos(cnpj.Substring(0, 12), multiplosCNPJ);
                int digito2 = CalcularDigitos(cnpj.Substring(0, 12) + digito1, multiplosCNPJ);
                if (!cnpj.Equals(cnpj.Substring(0, 12) + digito1.ToString() + digito2.ToString()))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
