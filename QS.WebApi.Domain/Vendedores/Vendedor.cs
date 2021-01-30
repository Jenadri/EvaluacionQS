using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.Vendedores
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
