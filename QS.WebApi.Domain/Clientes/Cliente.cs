using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WebApi.Domain.Clientes
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nic { get; set; }
        public char Categoria { get; set; }
    }
}
