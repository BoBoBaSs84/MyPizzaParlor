using Microsoft.AspNetCore.Components;
using PizzaParlor.Shared;

namespace PizzaParlor.Client.Pages
{
    public partial class PizzaItem
    {
        [Parameter]
        public Pizza Pizza { get; set; }
        [Parameter]
        public string ButtonTitle { get; set; }
        [Parameter]
        public string ButtonClass { get; set; }
        [Parameter]
        public EventCallback<Pizza> Selected { get; set; }
        private string SpicinessImage(Spiciness spiciness) => $"images/{spiciness.ToString().ToLower()}.png";
    }
}
