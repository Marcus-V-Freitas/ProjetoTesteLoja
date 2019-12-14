using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using DLL.BLL.Exceptions;
using DLL.BLL.Validacoes.StatusDaVenda;
using DLL.DAO.Conexao;
using DLL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Servicos.ServicoMysql
{
    public class VendaMysql : IVenda
    {
        private static AbstractDatabase objDAL;
        private static readonly VendaMysql _instance =new VendaMysql();
        private static FactoryStatus status;

        public static VendaMysql Instance()
        { 
            objDAL = FactoryBD.DAL();
            status = new FactoryStatus();
            return _instance;
        }
        
        private VendaMysql() { }

        public void CancelarVenda(int id)
        {
            string[] sql = new string[2];
            sql[0] = $"delete from produtosvenda where codigovenda='{id}'";
            sql[1] = $"delete from venda where codigo='{id}'";
            objDAL.ExecutarComandoSQLTransaction(sql);
        }

        public List<Venda> Listar()
        {
            List<Venda> lista = new List<Venda>();
            Venda venda;
            string sql = $"select v1.codigo, v1.valortotal, v1.datacompra, v2.codigo as formapagamento, v3.nome as cliente from venda v1 inner join formapagamento v2 on v1.formapagamento=v2.codigo " +
                $"inner join cliente v3 on v1.clientevenda=v3.codigo order by v1.codigo asc";
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                venda = new Venda()
                {
                    Codigo = Convert.ToInt32(dt.Rows[i]["codigo"]),
                    ValorTotal = Convert.ToDouble(dt.Rows[i]["valortotal"]),
                    DataCompra = Convert.ToDateTime(dt.Rows[i]["datacompra"]),
                    FormaPagamento = (FormaPagamento)dt.Rows[i]["formapagamento"],
                    Cliente = new ClienteFisico { Nome = dt.Rows[i]["cliente"].ToString() }
                };
                lista.Add(venda);
            }
            return lista;
            
        }

        public Venda Localizar(int id)
        {
            Venda venda;
            string sql = $"select v1.codigo, v1.valortotal, v1.datacompra, v2.codigo as formapagamento, v3.nome as cliente from venda v1 inner join formapagamento v2 on v1.formapagamento=v2.codigo " +
                $"inner join cliente v3 on v1.clientevenda=v3.codigo where v1.codigo='{id}' order by v1.codigo desc limit 1";
            DataTable dt = objDAL.RetDataTable(sql);

            venda = new Venda
            {
                Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]),
                ValorTotal = Convert.ToDouble(dt.Rows[0]["valortotal"]),
                DataCompra = Convert.ToDateTime(dt.Rows[0]["datacompra"]),
                FormaPagamento = (FormaPagamento)dt.Rows[0]["formapagamento"],
                Cliente = new ClienteFisico { Nome = dt.Rows[0]["cliente"].ToString() }
            };
            return venda;
        }

        public void RegistrarVenda(Venda venda)
        {
            string quantidade;
            foreach (var produto in venda.ProdutosVendas)
            {
               
                    quantidade = $"select estoque from produto where codigo='{produto.CodigoProduto}'order by codigo desc limit 1";

                    DataTable data = objDAL.RetDataTable(quantidade);

                    if ((Convert.ToInt32(data.Rows[0]["estoque"])) < produto.Quantidade)
                    {
                    venda.StatusVenda = status.GetStatus(null);
                    Console.WriteLine(venda.StatusVenda);
                        throw new DominioException("Limite");
                        
                        
                    }
               
            }

            string[] sql=new string[2];
            string dataCompra = DateTime.Now.Date.ToString("yyyy/MM/dd");

             sql[0] = "INSERT INTO venda(valortotal, formapagamento, datacompra, clientevenda)" +
                $"VALUES ('{venda.ValorTotal.ToString().Replace(",", ".")}','{(int)venda.FormaPagamento}','{dataCompra}','{venda.Cliente.Codigo}')";
            objDAL.ExecutarComandoSQL(sql[0]);

           
           sql[0] = $"select codigo FROM venda WHERE DataCompra='{dataCompra}' and clientevenda='{venda.Cliente.Codigo}' order by codigo desc limit 1";

            DataTable dt = objDAL.RetDataTable(sql[0]);
            string codigo = dt.Rows[0]["codigo"].ToString();
            
            foreach(var produto in venda.ProdutosVendas)
            {
                
                sql[0] = "insert into produtosvenda(codigovenda, codigoproduto, quantidade, precoUnitario) " +
                    $"values('{codigo}','{produto.CodigoProduto}', '{produto.Quantidade}','{produto.PrecoUnitario.ToString().Replace(",", ".")}')";

               //Baixa o produto do estoque
                sql[1] = $"update produto set estoque = (estoque -'{produto.Quantidade}') where codigo='{produto.CodigoProduto}'";


                objDAL.ExecutarComandoSQLTransaction(sql);
               
                
            }

            venda.StatusVenda = status.GetStatus(venda);
            Console.WriteLine(venda.StatusVenda);
        }
    }
}
