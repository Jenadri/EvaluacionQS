using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.Productos
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; }
    }
}
