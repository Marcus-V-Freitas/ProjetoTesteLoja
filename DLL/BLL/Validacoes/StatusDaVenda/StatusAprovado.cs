using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.BLL;
using DLL.BLL.Entidades;
using DLL.BLL.Enums;

namespace DLL.BLL.Validacoes.StatusDaVenda
{
    public class StatusAprovado : AbstractStatus
    {
        public override StatusVenda AlterarStatus(Venda venda)
        {
            return StatusVenda.Aprovado;
        }
    }
}
