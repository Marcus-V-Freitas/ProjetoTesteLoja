using DLL.BLL;
using DLL.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Conexao
{
    public class MemoriaDAO : AbstractDatabase
    {
        public static List<Cliente> Clientes = new List<Cliente>();

        public override void ExecutarComandoSQL(string sql)
        {
            throw new NotImplementedException();
        }

        public override void ExecutarComandoSQLTransaction(string[] paramsSQL)
        {
            throw new NotImplementedException();
        }

        public override void FecharConexaoSQL()
        {
            throw new NotImplementedException();
        }

        public override DataTable RetDataTable(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
