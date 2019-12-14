using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Conexao
{
   public abstract class AbstractDatabase
    {
        public abstract DataTable RetDataTable(string sql);
        public abstract void ExecutarComandoSQL(string sql);
        public abstract void ExecutarComandoSQLTransaction(string[] paramsSQL);
        public abstract void FecharConexaoSQL();
    }
}
