using DLL.BLL;
using DLL.BLL.Entidades;
using DLL.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL.Validacoes.StatusDaVenda
{
    public abstract class AbstractStatus
    {
        public abstract StatusVenda AlterarStatus(Venda venda); 
    }
}
