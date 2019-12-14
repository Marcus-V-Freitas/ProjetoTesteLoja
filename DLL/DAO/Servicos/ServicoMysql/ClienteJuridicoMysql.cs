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
    public class ClienteJuridicoMysql : ICliente
    {
        private static AbstractDatabase objDAL;

        private static readonly ClienteJuridicoMysql _instance = new ClienteJuridicoMysql();

        public static ClienteJuridicoMysql Instance()
        {
            objDAL = FactoryBD.DAL();
            return _instance;
        }

        public void Adicionar(Cliente cliente)
        {
            string sql;

            sql = $"INSERT INTO CLIENTE(nome,email) VALUES ('{cliente.Nome}', '{cliente.Email}')";

            objDAL.ExecutarComandoSQL(sql);

            sql = $"SELECT codigo from cliente where nome='{cliente.Email}' order by codigo desc limit 1";

            DataTable dt = objDAL.RetDataTable(sql);

            string codigo = dt.Rows[0]["codigo"].ToString();

            sql = $"insert into clientejuridico(codigojuridico,cnpj) values ('{codigo}', '{((ClienteJuridico)cliente).CNPJ}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Atualizar(Cliente cliente)
        {
            string[] sql = new string[2];
            sql[0] = $"update cliente set nome='{cliente.Nome}', email='{cliente.Email}' where codigo='{cliente.Codigo}'";
            sql[1] = $"update clientejuridico set cnpj='{((ClienteJuridico)cliente).CNPJ}' where codigojuridico='{cliente.Codigo}'";
            objDAL.ExecutarComandoSQLTransaction(sql);

        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            ClienteJuridico cliente;
            string sql = $"select v1.codigo, v1.nome, v1.email, v2.cnpj from cliente v1 inner join clientejuridico v2 on v1.codigo=v2.codigojuridico order by v1.codigo asc";
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cliente = new ClienteJuridico()
                {
                    Codigo = Convert.ToInt32(dt.Rows[i]["codigo"]),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    Email=dt.Rows[i]["email"].ToString(),
                    CNPJ = dt.Rows[i]["cnpj"].ToString()
                };
                lista.Add(cliente);
            }
            return lista;
        }

        public Cliente Localizar(int id)
        {
            ClienteJuridico cliente;
            string sql = $"select v1.codigo, v1.nome, v1.email, v2.cnpj from cliente v1 inner join clientejuridico v2 on v1.codigo=v2.codigojuridico where v1.codigo='{id}' order by v1.codigo asc";
            DataTable dt = objDAL.RetDataTable(sql);

            cliente = new ClienteJuridico
            {
                Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]),
                Nome = dt.Rows[0]["nome"].ToString(),
                Email=dt.Rows[0]["email"].ToString(),
                CNPJ = dt.Rows[0]["cnpj"].ToString()
            };

            return cliente;
        }

        public void Remover(int id)
        {
            string[] sql = new string[2];
            sql[0] = $"delete from clientejuridico where codigojuridico='{id}'";
            sql[1] = $"delete from cliente where codigo='{id}'";
            objDAL.ExecutarComandoSQLTransaction(sql);
        }
    }
}
