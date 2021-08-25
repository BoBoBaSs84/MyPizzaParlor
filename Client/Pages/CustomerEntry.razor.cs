using Microsoft.AspNetCore.Components;
using PizzaParlor.Client.Extensions;
using PizzaParlor.Shared;

namespace PizzaParlor.Client.Pages
{
    public partial class CustomerEntry
    {
        private InputWatcher inputWatcher;
        private bool isInvalid = true;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string ButtonTitle { get; set; }

        [Parameter]
        public string ButtonClass { get; set; }

        [Parameter]
        public Customer Customer { get; set; }

        [Parameter]
        public EventCallback<Customer> CustomerChanged { get; set; }

        [Parameter]
        public EventCallback Submit { get; set; }

        private void FieldChanged(string fieldName)
        {
            CustomerChanged.InvokeAsync(Customer);
            isInvalid = !inputWatcher.Validate();
        }
    }
}
