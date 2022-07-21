using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Interests
{
    
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    private string color { get; set; } 
    private string AnimationEntrance = "animate__animated animate__bounceInDown animate__delay-1s";
    private string AnimationExit = "animate__animated animate__bounceOutUp";
    protected override async void OnInitialized()
    {
        if (theme == "dark")
        {
            color = "rgba(93, 255, 0, 1)";
        }
        else
        {
            color = "black";
        }
        await Visible();

        StateHasChanged();

    }

    protected override Task OnParametersSetAsync()
    {
        color = theme == "dark" ? "rgba(93, 255, 0, 1)" : "black";
        return base.OnParametersSetAsync();
    }
  
    private string gridLoad ="hidden";
    public async Task Visible()
    {
        await Task.Delay(1000);
        gridLoad = "visible";
    }
}