using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components.Chat;

public partial class Chat : IAsyncDisposable
{
    [Inject] ChatState ChatState { get; set; }
    [Inject] AppState AppState { get; set; }
    private string ChatIconColor { get; set; } = "#d3d3d3";
    private string ChatMinimizeColor { get; set; } = "#d3d3d3";

    protected override void OnInitialized()
    {
        AppState.ThemeChanged += OnNotify;
        base.OnInitialized();
    }

    private async void OnNotify()
    {
        ChatIconColor = AppState.Theme == AppConstants.DarkTheme ? "#d3d3d3" : "white";
        ChatMinimizeColor = AppState.Theme == AppConstants.DarkTheme ? "#d3d3d3" : "black";
        await InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }
    
    public async ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
    }
}