using DLL.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Interfaces
{
    public interface IProduto
    {
        void Adicionar(Produto cliente);
        void Atualizar(Produto cliente);
        void Remover(int id);
        Produto Localizar(int id);
        List<Produto> Listar();
    }
}
