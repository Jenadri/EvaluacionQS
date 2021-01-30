using Microsoft.AspNetCore.Mvc;
using QS.WebApi.Domain.Clientes;
using QS.WebApi.Domain.InfrastuctureContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ICliente iCliente;

        public ClienteController(ICliente _iCliente)
        {
            iCliente = _iCliente;
        }

        [HttpGet, Route("ListarClientesCatASinFacturas")]
        public IActionResult GetClientesCatASinFacturas()
        {
            try
            {
                List<Cliente> clientes = iCliente.DAOGetClientesCatASinFacturas();
                return this.Ok(new
                {
                    state = "OK",
                    message = "Clientes de categoría ‘A’ y que no tengan ninguna factura emitida.",
                    detail = clientes
                });
            }
            catch (Exception exception)
            {

                return this.BadRequest(new
                {
                    state = "NOK",
                    message = exception.Message
                });
            }
        }
    }
}
