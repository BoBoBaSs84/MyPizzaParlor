using System.Collections.Generic;
using System.Linq;

namespace PizzaParlor.Shared
{
    public class Menu
    {
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Pizza GetPizza(int id) => Pizzas.SingleOrDefault(Pizza => Pizza.Id == id);
    }
}
