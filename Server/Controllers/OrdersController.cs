using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaParlor.Server.Data;
using PizzaParlor.Shared;

namespace PizzaParlor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaPlaceDbContext dbContext;
        public OrdersController(PizzaPlaceDbContext dbContext) => this.dbContext = dbContext;
        
        [HttpPost("/orders")]
        public IActionResult CreateOrder([FromBody] Basket basket)
        {
            Customer customer = basket.Customer;
            var order = new Order()
            {
                PizzaOrders = new List<PizzaOrder>()
            };
            customer.Order = order;
            foreach (int pizzaId in basket.Orders)
            {
                Pizza pizza = this.dbContext.Pizzas.Single(p => p.Id == pizzaId);
                order.PizzaOrders.Add(new PizzaOrder { Pizza = pizza, Order = order });
            }
            order.TotalPrice = order.PizzaOrders.Sum(po => po.Pizza.Price);
            this.dbContext.Add(customer);
            this.dbContext.SaveChanges();
            return Ok();
        }

    }
}
