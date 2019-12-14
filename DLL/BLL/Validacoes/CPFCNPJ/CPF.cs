using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ
{
    public class CPF : DecoratorCalculo
    {
        //Números para multiplos do CPF
        private static readonly int[] multiplosCPF = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };


        public CPF(AbstractCalculo abstractCalculo) : base(abstractCalculo)
        {
        }

        public bool ValidarCPF(string cpf)
        {
            if (cpf==null)
            {
                return false;
            }

            //Expressão regular para retirar quaisquer dados que não sejam números
            var apenasDigitos = new Regex(@"[^\d]");
            cpf = apenasDigitos.Replace((string)cpf, "");

            if ((cpf.Length == 11))
            {
                int digito1 = CalcularDigitos(cpf.Substring(0, 9), multiplosCPF);
                int digito2 = CalcularDigitos(cpf.Substring(0, 9) + digito1, multiplosCPF);
                if (!cpf.Equals(cpf.Substring(0, 9) + digito1.ToString() + digito2.ToString()))
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
