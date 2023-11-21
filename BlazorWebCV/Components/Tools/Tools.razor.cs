using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components.Tools;

public partial class Tools
{
    [Inject] private IOptions<ToolsModel> ToolsModel { get; set; }
}