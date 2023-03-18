using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace BlazorWebCV.Pages;

public partial class Tools
{
    [Inject] private IOptions<ToolsModel> ToolsModel { get; set; }
}