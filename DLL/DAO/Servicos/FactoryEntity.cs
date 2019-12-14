using DLL.DAO.Interfaces;
using DLL.DAO.Servicos.ServicoMysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Servicos
{
    //Fabrica para criação das entidades de acesso a dados de mesma indentidade que as do sistema
    public static class FactoryEntity
    {

        public static ICliente ClienteFisico()
        {
            return ClienteFisicoMysql.Instance();
        }

        public static ICliente ClienteJuridico()
        {
            return ClienteJuridicoMysql.Instance();
        }

        public static IVenda Venda()
        {
            return VendaMysql.Instance();
        }


    }
}
