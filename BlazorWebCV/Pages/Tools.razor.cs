using System.Linq;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace BlazorWebCV.Pages;

public partial class Tools
{
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] private IOptions<ToolsModel> ToolsModel { get; set; }
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    private string gridLoad ="hidden";
    protected override async Task OnInitializedAsync()
    {
        await Visible();

        StateHasChanged();
    }

    public async Task Visible()
    {
        await Task.Delay(1000);
        gridLoad = "visible";
    }
    private async Task Click(string name)
    {
        await JsRuntime.InvokeAsync<object>("open", ToolsModel.Value.Tools.Values.FirstOrDefault(i=>i["text"]!.Equals(name))!["reference"], "_blank");
    }
}