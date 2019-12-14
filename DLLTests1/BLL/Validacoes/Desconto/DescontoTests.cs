using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using DLL.BLL.Validacoes.Desconto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLTests1.BLL.Validacoes.Desconto
{
    [TestClass()]
    public class DescontoTests
    {
        private Venda venda = new Venda();

        [TestMethod]
        public void TesteCartaoCredito()
        {
            //10%
            venda.ValorTotal = 1000;
            venda.FormaPagamento = FormaPagamento.CartaoCredito;

            venda.Descontar();

            Assert.AreEqual(900, venda.ValorTotal);

        }

        [TestMethod()]
        public void TesteBoleto()
        {
            //5%
            venda.ValorTotal = 1000;
            venda.FormaPagamento = FormaPagamento.Boleto;

            venda.Descontar();

            Assert.AreEqual(950, venda.ValorTotal);
        }

        [TestMethod()]
        public void TesteDinheiro()
        {
            //15%
            venda.ValorTotal = 1000;
            venda.FormaPagamento = FormaPagamento.Dinheiro;

            venda.Descontar();

            Assert.AreEqual(850, venda.ValorTotal);
        }


    }
}
