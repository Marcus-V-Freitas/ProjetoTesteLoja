using DLL.BLL.Validacoes.CPFCNPJ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLTests1.BLL.Validacoes.CPFCNPJ
{
    [TestClass()]
    public class CNPJTests
    {
        [TestMethod]
        public void CNPJVerdadeiro()
        {
            CNPJ cnpj = new CNPJ(new CalculoCPFCNPJ());
            Assert.IsTrue(cnpj.ValidarCNPJ("935.852.870.001.40"));

        }

        [TestMethod]
        public void CNPJFalso()
        {
            CNPJ cnpj = new CNPJ(new CalculoCPFCNPJ());
            Assert.IsFalse(cnpj.ValidarCNPJ("847.342.123.423.83"));
        }
    }
}
