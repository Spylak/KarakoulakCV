using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.Configure<SkillsModel>(options =>
                builder.Configuration.GetSection("Skills").Bind(options));
            builder.Services.Configure<ProjectsModel>(options =>
                builder.Configuration.Bind(options)); 
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