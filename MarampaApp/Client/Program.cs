using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarampaApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            var builder = WebAssemblyHostBuilder.CreateDefault(args);


            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddSweetAlert2();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("MarampaApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MarampaApp.ServerAPI"));

            builder.Services.AddApiAuthorization();

            var host = builder.Build();


            await host.RunAsync();
        }
    }
}
