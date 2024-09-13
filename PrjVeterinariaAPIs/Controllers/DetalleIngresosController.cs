using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleIngresosController : ControllerBase
    {
        private readonly DetalleIngresosDAO daodetalleingreso;

        public DetalleIngresosController(DetalleIngresosDAO detalleingreso)
        {
            daodetalleingreso = detalleingreso;
        }

        [HttpGet("GetDetalleIngresos/{idingre}")]
        public async Task<ActionResult<List<PA_LISTAR_INGRESOS>>> GetDetalleIngresos(int idingre)
        {
            var listado = await Task.Run(() => daodetalleingreso.GetDetalleIngresos(idingre));

            return Ok(listado);
        }

        [HttpPost("GrabarDetalleIngresos")]
        public async Task<ActionResult<string>> GrabarDetalleIngresos([FromBody] DetalleIngresos obj)
        {
            string mensaje = await Task.Run(() => daodetalleingreso.GrabarDetalleIngresos(obj));
            return Ok(mensaje);
        }

        [HttpPut("EliminarDetalleIngresos")]
        public async Task<ActionResult<string>> EliminarDetalleIngresos([FromBody] DetalleIngresoParams obj)
        {
            string mensaje = await Task.Run(() => daodetalleingreso.EliminarDetalleIngresos(obj));
            return Ok(mensaje);
        }

        [HttpPut("RestaurarDetalleIngresos")]
        public async Task<ActionResult<string>> RestaurarDetalleIngresos([FromBody] DetalleIngresoParams obj)
        {
            string mensaje = await Task.Run(() => daodetalleingreso.RestaurarDetalleIngresos(obj));
            return Ok(mensaje);
        }

    }
}
