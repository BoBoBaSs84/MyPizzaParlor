using Microsoft.AspNetCore.Components;
using PizzaParlor.Shared;
using PizzaParlor.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace PizzaParlor.Client.Pages
{
    public partial class Index
    {
        [Inject]
        private IMenuService MenuService { get; set; }
        [Inject]
        private IOrderService OrderService { get; set; }
        private State State { get; } = new State();

        protected override async Task OnInitializedAsync()
        {
            State.Menu = await MenuService.GetMenu();
        }

        private void AddToBasket(Pizza pizza)
        {
            Console.WriteLine($"Added pizza {pizza.Name}");
            State.Basket.Add(pizza.Id);
        }

        private void RemoveFromBasket(int pos)
        {
            Console.WriteLine($"Removing pizza at pos {pos}");
            State.Basket.RemoveAt(pos);
        }

        private async Task PlaceOrder()
        {
            await OrderService.PlaceOrder(State.Basket);
        }
    }
}
