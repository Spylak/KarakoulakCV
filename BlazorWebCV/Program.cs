using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace BlazorWebCV
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddMudServices();
            builder.Services.AddMediaQueryService();
            builder.Services.AddScoped<ResizeListener>();
            builder.Services.AddResizeListener(options =>
                            {
                                options.ReportRate = 300;
                                options.EnableLogging = true;
                                options.SuppressInitEvent = true;
                            });
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            await builder.Build().RunAsync();
        }
    }
}