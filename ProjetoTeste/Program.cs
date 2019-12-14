using DLL.BLL;
using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using DLL.BLL.Validacoes.CPFCNPJ;
using DLL.BLL.Validacoes.Desconto;
using DLL.DAO.Conexao;
using DLL.DAO.Interfaces;
using DLL.DAO.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste
{
    class Program
    {
        static void Main(string[] args)
        {
           
          

                AbstractDatabase objDAL = FactoryBD.StringConexao();



            List<ProdutosVenda> produtos = new List<ProdutosVenda>() { new ProdutosVenda(1, 1, 1000) };


            double valor = 0;

                produtos.ForEach(x => valor+=x.PrecoUnitario);

            Venda venda = new Venda(valor, FormaPagamento.Dinheiro, new ClienteJuridico { Codigo = 20, Nome = "Ernane", Email = "ernane1",Nascimento=DateTime.Now, CNPJ = "123" },produtos);
            venda.Descontar();


            IVenda vendas = FactoryEntity.Venda();
            vendas.RegistrarVenda(venda);

      

        }
    }

   
}
