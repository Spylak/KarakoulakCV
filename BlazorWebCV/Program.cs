using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using MudExtensions.Services;

namespace BlazorWebCV
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddMudServices();
            builder.Services.AddMudExtensions();
            builder.Services.AddOptions();
            builder.Services.AddSingleton<ChatMessagesContainer>();
            builder.Services.Configure<SkillsModel>(options =>
                builder.Configuration.GetSection("Skills").Bind(options));
            builder.Services.Configure<ToolsModel>(options =>
                builder.Configuration.Bind(options));
            builder.Services.Configure<ExperienceModel>(options =>
                builder.Configuration.Bind(options));
            builder.Services.Configure<CertsModel>(options =>
                builder.Configuration.Bind(options));
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            await builder.Build().RunAsync();
        }
    }
}