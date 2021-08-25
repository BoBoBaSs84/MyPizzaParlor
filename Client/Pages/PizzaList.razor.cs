using Microsoft.AspNetCore.Components;
using PizzaParlor.Shared;

namespace PizzaParlor.Client.Pages
{
    public partial class PizzaList
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public Menu Menu { get; set; }
        [Parameter]
        public EventCallback<Pizza> Selected { get; set; }
    }
}
