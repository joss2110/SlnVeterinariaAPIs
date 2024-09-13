using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesDAO daocli;

        public ClientesController(ClientesDAO cli)
        {
            daocli = cli;
        }

        [HttpGet("GetClientes")]
        public async Task<ActionResult<List<Clientes>>> GetClientes()
        {
            var listado = await Task.Run(() => daocli.GetClientes());

            return Ok(listado);
        }

        [HttpPost("GrabarClientes")]

        public async Task<ActionResult<string>> GrabarCliente([FromBody] Clientes obj)
        {
            string mensaje = await Task.Run(() => daocli.GrabarCliente(obj));

            return Ok(mensaje);
        }

        [HttpPut("ActualizarClientes")]
        public async Task<ActionResult<string>> ActualizarCliente([FromBody] Clientes obj)
        {
            string mensaje = await Task.Run(() => daocli.ActualizarCliente(obj));

            return Ok(mensaje);
        }

        [HttpDelete("EliminarCliente/{id}")]
        public async Task<ActionResult<string>> EliminarCliente(int id)
        {
            string mensaje = await Task.Run(() => daocli.EliminarClientes(id));

            return Ok(mensaje);
        }

        [HttpDelete("RestaurarCliente/{id}")]
        public async Task<ActionResult<string>> RestaurarCliente(int id)
        {
            string mensaje = await Task.Run(() => daocli.RestaurarClientes(id));

            return Ok(mensaje);
        }
    }
}
