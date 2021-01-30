using Microsoft.AspNetCore.Mvc;
using QS.WebApi.Domain.Facturas;
using QS.WebApi.Domain.InfrastuctureContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private readonly IFactura iFactura;

        public FacturaController(IFactura _iFactura)
        {
            iFactura = _iFactura;
        }

        [HttpGet, Route("ListarFacturasPorDia")]
        public IActionResult GetFacturasByDays()
        {
            try
            {
                List<Factura> facturas = iFactura.DAOGetFacturas();
                return this.Ok(new
                {
                    state = "OK",
                    message = "Facturas emitidas por día ordenado por el importe de mayor a menor.",
                    detail = facturas
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

        [HttpPost, Route("CrearFactura")]
        /*
            {
              "facturaId": -1,
              "vendedorId": 1,
              "clienteId": 1,
              "fecha": "2021-04-01",
              "moneda": "SOL",
              "detalles": [
                {
                  "facturaId": -1,
                  "productoId": 1,
                  "cantidad": 10,
                  "precioUnitario": 200
                }
              ]
            }
        */
        public IActionResult CreateFactura([FromBody] Factura factura)
        {
            try
            {
                bool isCreate = iFactura.DAOCreateFactura(factura);
                if (isCreate)
                {
                    return this.Ok(new
                    {
                        state = "OK",
                        message = "Factura creada con éxito.",
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        state = "NOK",
                        message = "Factura sin productos o sin cantidad de productos.",
                    });
                }                
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
