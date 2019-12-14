using DLL.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Interfaces
{
   public interface ICliente
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(int id);
        Cliente Localizar(int id);
        List<Cliente> Listar();

    }
}
