using FlowersshoesCoreMVC.DAO;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;


namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StocksDAO daostock;

        public StocksController(StocksDAO daoStock)
        {
            daostock = daoStock;
        }

        //GET:Stocks
        [HttpGet("GetStocks")]
        public async Task<ActionResult<List<Stocks>>> GetStocks()
        {
            var listado = await Task.Run(() => daostock.getStocks());
            //
            return Ok(listado);
        }
    }
}
