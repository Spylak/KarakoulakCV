using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components;
public partial class Interests
{
    [Inject] AppState AppState { get; set; }
    private string color { get; set; } 
    private string AnimationEntrance = "animate__animated animate__bounceInDown animate__delay-1s";
    private string AnimationExit = "animate__animated animate__bounceOutUp";
    protected override async void OnInitialized()
    {
        if (AppState.Theme == AppConstants.DarkTheme)
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
        color = AppState.Theme == AppConstants.DarkTheme ? "rgba(93, 255, 0, 1)" : "black";
        return base.OnParametersSetAsync();
    }
  
    private string gridLoad ="hidden";
    public async Task Visible()
    {
        await Task.Delay(1000);
        gridLoad = "visible";
    }
}