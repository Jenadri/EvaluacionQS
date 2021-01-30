using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.Facturas
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        //Extras
        public Factura Factura { get; set; }
    }
}
