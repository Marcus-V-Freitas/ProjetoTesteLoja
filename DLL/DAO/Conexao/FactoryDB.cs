using DLL.DAO.Conexao.Mysql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Conexao
{
    //Fabrica para criar conexão com a base de dados
    public static class FactoryBD
    {
        public static AbstractDatabase StringConexao()
        {
            //Inicializa os dados da string de conexão e depois retornar a instância
            DataDal.StringConexao();
            return MysqlDAO.Instance();
        }

        public static AbstractDatabase DAL()
        {
            return MysqlDAO.Instance();
        }

    }
}
