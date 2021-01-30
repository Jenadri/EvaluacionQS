using QS.WebApi.Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.InfrastuctureContratos
{
    public interface ICliente
    {
        List<Cliente> DAOGetClientesCatASinFacturas();
    }
}
