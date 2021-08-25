using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PizzaParlor.Shared;
using PizzaParlor.Shared.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaParlor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<IMenuService, HardCodedMenuService>();
            builder.Services.AddTransient<IOrderService, ConsoleOrderService>();
            builder.Services.AddTransient(opt => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<State>();
            await builder.Build().RunAsync();
        }
    }
}
