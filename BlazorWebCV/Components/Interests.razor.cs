using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components;
public partial class Interests : IAsyncDisposable
{
    [Inject] AppState AppState { get; set; }
    private string color { get; set; } = "black";
    private string AnimationEntrance = "animate__animated animate__bounceInDown";
    private string AnimationExit = "animate__animated animate__bounceOutUp";
    
    protected override async Task OnInitializedAsync()
    {
        AppState.ThemeChanged += OnNotify;
        await Visible();
        base.OnInitialized();
    }

    private async void OnNotify()
    {
        color = AppState.Theme == AppConstants.DarkTheme ? "#d3d3d3" : "black";
        await InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }
    
    public async ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
    }
    
    private string gridLoad ="hidden";
    public async Task Visible()
    {
        OnNotify();
        await Task.Delay(1000);
        gridLoad = "visible";
    }
}