using System;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;

namespace BlazorWebCV.Components.Experience;


public partial class Experience : IAsyncDisposable
{
    [Inject] private IOptions<ExperienceModel> ExperienceModel { get; set; } = default!;
    [Inject] private AppState AppState { get; set; } = null!;
    private Color Color { get; set; } = Color.Default;
    protected override void OnInitialized()
    {
        AppState.ThemeChanged += OnNotify;
        AppState.BreakpointChanged += OnNotify;
        base.OnInitialized();
    }

    private async void OnNotify()
    {
        Color = AppState.Theme == AppConstants.DarkTheme ? Color.Default : Color.Dark;
        await InvokeAsync(StateHasChanged);
    }
    
    public ValueTask DisposeAsync()
    {
        AppState.BreakpointChanged -= OnNotify;
        AppState.ThemeChanged -= OnNotify;
        return ValueTask.CompletedTask;
    }
}