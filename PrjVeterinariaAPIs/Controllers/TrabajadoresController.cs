using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly TrabajadoresDAO daotra;

        public TrabajadoresController(TrabajadoresDAO daoTra)
        {
            daotra = daoTra;
        }

        // GET:Trabajadores
        // http://localhost:5050/api/Trabajadores/GetTrabajadores
        [HttpGet("GetTrabajadores")]
        public async Task<ActionResult<List<PA_LISTAR_TRABAJADORES>>> GetTrabajadores()
        {
            var listado = await Task.Run(() => daotra.getTrabajadores());
            //
            return Ok(listado);
        }

        // POST:Trabajadores
        // http://localhost:5050/api/Trabajadores/GrabarTrabajadores
        [HttpPost("GrabarTrabajadores")]
        public async Task<ActionResult<String>> GrabarTrabajadoresPost([FromBody] Trabajadores obj)
        {
            string mensaje = await Task.Run(() => daotra.GrabarTrabajador(obj));
            //
            return Ok(mensaje);
        }

        // PUT:Trabajadore
        // http://localhost:5050/api/Trabajadores/ActualizarTrabajadores
        [HttpPut("ActualizarTrabajadores")]
        public async Task<ActionResult<String>> ActualizarTrabajadoresPut([FromBody] Trabajadores obj)
        {
            string mensaje = await Task.Run(() => daotra.ActualizarTrabajador(obj));
            //
            return Ok(mensaje);
        }

        // DELETE:Trabajadores
        // http://localhost:5050/api/Trabajadores/DeleteTrabajadores/4
        [HttpDelete("DeleteTrabajadores/{id}")]
        public async Task<ActionResult<String>> DeleteTrabajadores(int id)
        {
            string mensaje = await Task.Run(() => daotra.EliminarTrabajador(id));
            //
            return Ok(mensaje);
        }

        // RESTAURAR
        // http://localhost:5050/api/TrabajadoresAPI/RestaurarTrabajadores/4
        [HttpDelete("RestaurarTrabajadores/{id}")]
        public async Task<ActionResult<String>> RestaurarTrabajadores(int id)
        {
            string mensaje = await Task.Run(() => daotra.RestaurarTrabajador(id));
            //
            return Ok(mensaje);
        }


    }
}
