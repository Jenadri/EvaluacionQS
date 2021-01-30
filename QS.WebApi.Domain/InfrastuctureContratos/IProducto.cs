using QS.WebApi.Domain.Productos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.InfrastuctureContratos
{
    public interface IProducto
    {
        List<Producto> DAOGetProductos();
    }
}
