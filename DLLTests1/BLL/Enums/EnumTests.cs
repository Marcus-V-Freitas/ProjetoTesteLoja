using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.BLL.Enums;

namespace DLLTests1.BLL.Enums
{
    [TestClass()]
    public class EnumTests
    {

        [TestMethod()]
        public void ValorFormaPagamento()
        {
            int boleto = (int)FormaPagamento.Boleto;
            Assert.AreEqual(1, boleto);
        }
    }
}
