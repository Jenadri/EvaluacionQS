using QS.WebApi.Domain.Facturas;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.InfrastuctureContratos
{
    public interface IFactura
    {
        List<Factura> DAOGetFacturas();
        bool DAOCreateFactura(Factura factura);
        //int InsertFactura(Factura factura);
        //int InsertDetalleFactura(DetalleFactura factura);        
    }
}
