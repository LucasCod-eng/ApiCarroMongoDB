using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Model;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly CarroServices _carroservices;

        public CarroController(CarroServices carroservices)
        {
            _carroservices = carroservices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Carro>>> BuscarTodosCarros()
        {
            List<Carro> carros = await _carroservices.GetAsync();
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> BuscaPorId(string id)
        {
            Carro carro = await _carroservices.GetAsync(id);
            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> Cadastrar(Carro carro)
        {
            await _carroservices.CreateAsync(carro);
            return Ok(carro);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Carro>> Apagar(string id)
        {
            await _carroservices.RemoveAsync(id);
            
            return Ok();
        }

    }
}

