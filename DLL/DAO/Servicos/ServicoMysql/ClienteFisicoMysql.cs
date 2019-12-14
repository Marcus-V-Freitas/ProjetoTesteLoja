using DLL.BLL.Entidades;
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
    public class ClienteFisicoMysql : ICliente
    {
       private static AbstractDatabase objDAL;
        private static readonly ClienteFisicoMysql _instance = new ClienteFisicoMysql();

        private ClienteFisicoMysql() { }

        public static ClienteFisicoMysql Instance()
        {
            objDAL = FactoryBD.DAL();
            return _instance;
        }

        public void Adicionar(Cliente cliente)
        {
            string sql;

            sql = $"INSERT INTO Cliente(nome,email) VALUES ('{cliente.Nome}','{cliente.Email}')";

            objDAL.ExecutarComandoSQL(sql);

            sql = $"select codigo FROM Cliente WHERE email='{cliente.Email}' order by codigo desc limit 1";

            DataTable dt = objDAL.RetDataTable(sql);
            string codigo = dt.Rows[0]["codigo"].ToString();

            sql = "insert into clientefisico(codigofisico,cpf) " +
                $"values('{codigo}','{((ClienteFisico)cliente).CPF}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Atualizar(Cliente cliente)
        {
            string[] sql = new string[2];
            sql[0] = $"UPDATE CLIENTE SET NOME='{cliente.Nome}', email='{cliente.Email}' where codigo='{cliente.Codigo}'";
            sql[1] = $"UPDATE CLIENTEFISICO SET CPF='{((ClienteFisico)cliente).CPF}' where codigofisico='{cliente.Codigo}'";

            objDAL.ExecutarComandoSQLTransaction(sql);
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            ClienteFisico cliente;
            string sql = $"SELECT v1.codigo, v1.nome, v1.email, v2.cpf from cliente v1 inner join clientefisico v2 on v1.codigo=v2.codigofisico order by v1.codigo asc";
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cliente = new ClienteFisico
                {
                    Codigo = Convert.ToInt32(dt.Rows[i]["codigo"]),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    Email=dt.Rows[i]["email"].ToString(),
                    CPF = dt.Rows[i]["cpf"].ToString(),

                };
                lista.Add(cliente);

            }
            return lista;
        }

        public Cliente Localizar(int id)
        {
            ClienteFisico cliente;
            string sql = $"SELECT v1.codigo, v1.nome, v1.email, v2.cpf from cliente v1 inner join clientefisico v2 on v1.id=v2.codigofisico where v1.codigo='{id}' order by v1.nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            cliente = new ClienteFisico
            {
                Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]),
                Nome = dt.Rows[0]["nome"].ToString(),
                Email=dt.Rows[0]["email"].ToString(),
                CPF = dt.Rows[0]["cpf"].ToString()

            };

            return cliente;
        }

        public void Remover(int id)
        {
            string[] sql = new string[2];
            sql[0] = $"DELETE FROM CLIENTEFISICO WHERE codigofisico='{id}'";
            sql[1] = $"DELETE FROM CLIENTE WHERE codigo='{id}'";
     
            
            objDAL.ExecutarComandoSQLTransaction(sql);
        }
    }
}
