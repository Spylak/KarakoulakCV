using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components.Chat;

public partial class Chat : IAsyncDisposable
{
    [Inject] ChatState ChatState { get; set; }
    [Inject] AppState AppState { get; set; }
    private string ChatIconColor { get; set; } = "rgba(93,255,0,1)";
    private string ChatMinimizeColor { get; set; } = "rgba(93,255,0,1)";

    protected override void OnInitialized()
    {
        AppState.ThemeChanged += OnNotify;
        base.OnInitialized();
    }

    private async void OnNotify()
    {
        ChatIconColor = AppState.Theme == AppConstants.DarkTheme ? "rgba(93, 255, 0, 1)" : "white";
        ChatMinimizeColor = AppState.Theme == AppConstants.DarkTheme ? "rgba(93, 255, 0, 1)" : "black";
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