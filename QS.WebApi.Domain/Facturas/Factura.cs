using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.Facturas
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public string Serie { get; set; }
        public string Codigo { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }

        //Extras
        public string Dia { get; set; }
        public decimal Importe { get; set; }
        public string NombreCliente { get; set; }
        public string NombreVendedor { get; set; }

        public List<DetalleFactura> Detalles { get; set; }
    }
}
