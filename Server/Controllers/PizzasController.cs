using Microsoft.AspNetCore.Mvc;
using PizzaParlor.Server.Data;
using PizzaParlor.Shared;
using System.Collections.Generic;
using System.Linq;

namespace PizzaParlor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaPlaceDbContext dbContext;
        public PizzasController(PizzaPlaceDbContext dbContext) => this.dbContext = dbContext;

        [HttpGet("pizzas")]
        public IQueryable<Pizza> GetPizzas() => this.dbContext.Pizzas;

        [HttpPost("pizzas")]
        public IActionResult InsertPizza([FromBody] Pizza pizza)
        {
            dbContext.Pizzas.Add(pizza);
            dbContext.SaveChanges();
            return Created($"pizzas/{pizza.Id}", pizza);
        }
    }
}
