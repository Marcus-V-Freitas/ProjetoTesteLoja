using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL.BLL.Validacoes.CPFCNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.CPFCNPJ.Tests
{
    [TestClass()]
    public class CPFTests
    {
        [TestMethod()]
        public void CPFVerdadeiro()
        {
            CPF cpf = new CPF(new CalculoCPFCNPJ());

           Assert.IsTrue(cpf.ValidarCPF("176.962.708.18"));
        }

        [TestMethod()]
        public void CPFFalso()
        {
            CPF cpf = new CPF(new CalculoCPFCNPJ());

            Assert.IsFalse(cpf.ValidarCPF("133.952.790.10"));
        }


    }
}