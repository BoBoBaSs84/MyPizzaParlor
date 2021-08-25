using PizzaParlor.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace PizzaParlor.Shared
{
    public class ConsoleOrderService : IOrderService
    {
        public async Task PlaceOrder(Basket basket)
        {
            Console.WriteLine($"Placing order for {basket.Customer.Name}");
            await Task.CompletedTask;
        }
    }
}
