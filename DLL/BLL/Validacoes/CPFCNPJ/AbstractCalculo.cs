using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ
{
    public abstract class AbstractCalculo
    {
        public abstract int CalcularDigitos(string strings, int[] tamanho);
    }
}
