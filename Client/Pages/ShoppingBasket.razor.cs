using Microsoft.AspNetCore.Components;
using PizzaParlor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaParlor.Client.Pages
{
    public partial class ShoppingBasket
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public Basket Basket { get; set; }
        [Parameter]
        public EventCallback<int> Selected { get; set; }
        [Parameter]
        public decimal TotalPrice { get; set; }
        [Parameter]
        public Func<int, Pizza> GetPizzaFromId { get; set; }
        public IEnumerable<(Pizza pizza, int pos)> Pizzas { get; set; }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Pizzas = Basket.Orders.Select((id, pos) => (pizza: GetPizzaFromId(id), pos));
            TotalPrice = Pizzas.Select(tuple => tuple.pizza.Price).Sum();
        }
    }
}
