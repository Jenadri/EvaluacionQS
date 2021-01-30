using Microsoft.AspNetCore.Mvc;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WebApi.Domain.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly IVendedor iVendedor;

        public VendedorController(IVendedor _iVendedor)
        {
            iVendedor = _iVendedor;
        }

        [HttpGet, Route("ListarVendedores2019")]
        public IActionResult GetVendedores2019()
        {
            try
            {
                List<Vendedor> vendedores = iVendedor.DAOGetVendedores2019();
                return this.Ok(new
                {
                    state = "OK",
                    message = "Listar los vendedores que ingresaron en el 2019.",
                    detail = vendedores
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
