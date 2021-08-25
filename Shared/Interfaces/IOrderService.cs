using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Shared.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(Basket basket);
    }
}
