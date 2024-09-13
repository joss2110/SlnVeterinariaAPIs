using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController : ControllerBase
    {
        private readonly ColoresDAO daocolor;

        public ColoresController(ColoresDAO color)
        {
            daocolor = color;
        }

        [HttpGet("GetColores")]
        public async Task<ActionResult<List<Colores>>> GetColores()
        {
            var listado = await Task.Run(() => daocolor.GetColores());

            return Ok(listado);
        }

        [HttpPost("GrabarColor")]
        public async Task<ActionResult<string>> GrabarColor([FromBody] Colores obj)
        {
            string mensaje = await Task.Run(() => daocolor.GrabarColor(obj));
            return Ok(mensaje);
        }

        [HttpPut("ActualizarColor")]
        public async Task<ActionResult<string>> ActualizarColor([FromBody] Colores obj)
        {
            string mensaje = await Task.Run(() => daocolor.ActualizarColor(obj));
            return Ok(mensaje);
        }

        [HttpDelete("EliminarColor/{id}")]
        public async Task<ActionResult<string>> EliminarColor(int id)
        {
            string mensaje = await Task.Run(() => daocolor.EliminarColor(id));
            return Ok(mensaje);
        }

        [HttpDelete("RestaurarColor/{id}")]
        public async Task<ActionResult<string>> RestaurarColor(int id)
        {
            string mensaje = await Task.Run(() => daocolor.RestaurarColor(id));
            return Ok(mensaje);
        }



    }
}
