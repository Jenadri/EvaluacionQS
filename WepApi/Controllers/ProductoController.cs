using Microsoft.AspNetCore.Mvc;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WebApi.Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProducto iProducto;

        public ProductoController(IProducto _iProducto)
        {
            iProducto = _iProducto;
        }

        [HttpGet, Route("ListarProductos")]
        public IActionResult GetProductos()
        {
            try
            {
                List<Producto> productos = iProducto.DAOGetProductos();
                return this.Ok(new
                {
                    state = "OK",
                    message = "Listar todos los productos.",
                    detail = productos
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
