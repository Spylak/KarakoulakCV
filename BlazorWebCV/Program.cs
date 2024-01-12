global using BlazorWebCV.Constants;
using System;
using System.Net.Http;
using BlazorWebCV;
using BlazorWebCV.Components.Certifications;
using BlazorWebCV.Components.Chat;
using BlazorWebCV.Components.Experience;
using BlazorWebCV.Components.Skills;
using BlazorWebCV.Components.Tools;
using BlazorWebCV.Services;
using BlazorWebCV.Services.IServices;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddMudServices();
builder.Services.AddMudExtensions();
builder.Services.AddOptions();
builder.Services.AddSingleton<ChatState>();
builder.Services.AddSingleton<AppState>();
builder.Services.Configure<SkillsModel>(options =>
    builder.Configuration.GetSection("Skills").Bind(options));
builder.Services.Configure<ToolsModel>(options =>
    builder.Configuration.Bind(options));
builder.Services.Configure<ExperienceModel>(options =>
    builder.Configuration.Bind(options));
builder.Services.Configure<CertsModel>(options =>
    builder.Configuration.Bind(options));
builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IGlobalFunctionService, GlobalFunctionService>();

await builder.Build().RunAsync();