using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ
{
    public class CalculoCPFCNPJ : AbstractCalculo
    {

        public override int CalcularDigitos(string strings, int[] tamanho)
        {
            int soma = 0;
            for (int indice = strings.Length - 1, digito; indice >= 0; indice--)
            {
                digito = int.Parse(strings.Substring(indice, 1));
                soma += digito * tamanho[tamanho.Length - strings.Length + indice];
            }
            soma = 11 - soma % 11;
            return soma > 9 ? 0 : soma;
        }
    }
}
