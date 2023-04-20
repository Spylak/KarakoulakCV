using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Index
{
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    [CascadingParameter(Name = "Breakpoint")]
    protected Breakpoint CurrentBreakpoint { get; set; }
    [Inject]
    private IJSRuntime jsRuntime { get; set; }
    private string ImageStyle { get; set; }
    private  string color { get; set; }
    private int count = 0;
    protected override void OnParametersSet()
    {
        color = theme == "dark" ? "black" : "#bfbbbb";
        ImageStyle =
            (CurrentBreakpoint.Equals(Breakpoint.Xs) ? "width: 100%;height: 50vh" : "width: 100%;height: 70vh;") +
            "border-radius: 5px";
        base.OnParametersSet();
    }
    private string AnimationEntrance = "animate__animated animate__lightSpeedInLeft animate__delay-1s";
    private string AnimationExit = "animate__animated animate__lightSpeedOutRight";
    private async Task OnClick()
    {
        count++;
        if (count > 3)
        {
            count = 0;
        }
    }
    private bool matrix = true;

    protected override async Task OnInitializedAsync()
    {
        await Matrix();
        base.OnInitialized();
    }

    private async Task Matrix()
    {
        await Task.Delay(1000);
        matrix = false;
        StateHasChanged();
    }
}