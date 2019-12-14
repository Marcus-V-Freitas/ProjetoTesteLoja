using DLL.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Interfaces
{
    public interface IVenda
    {
        void RegistrarVenda(Venda venda);
        void CancelarVenda(int id);
        Venda Localizar(int id);
        List<Venda> Listar();
    }
}
