using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components;
public partial class Interests : IAsyncDisposable
{
    [Inject] AppState AppState { get; set; } = null!;
    private string _color = "black";
    private string _gridLoad ="hidden";
    private string _animationEntrance = "animate__animated animate__bounceInDown";
    private string _animationExit = "animate__animated animate__bounceOutUp";
    
    protected override async Task OnInitializedAsync()
    {
        AppState.ThemeChanged += OnNotify;
        await Visible();
        await base.OnInitializedAsync();
    }

    private async void OnNotify()
    {
        _color = AppState.Theme == AppConstants.DarkTheme ? "#d3d3d3" : "black";
        await InvokeAsync(StateHasChanged);
    }
    
    public ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
        return ValueTask.CompletedTask;
    }
    

    private async Task Visible()
    {
        OnNotify();
        await Task.Delay(1000);
        _gridLoad = "visible";
    }
}