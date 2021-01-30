using QS.WebApi.Domain.Vendedores;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.InfrastuctureContratos
{
    public interface IVendedor
    {
        List<Vendedor> DAOGetVendedores2019();
    }
}
