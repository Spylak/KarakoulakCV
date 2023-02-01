using System.Linq;
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