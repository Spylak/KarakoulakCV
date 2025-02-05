using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Index : IAsyncDisposable
{
    [Inject] private AppState AppState { get; set; } = null!;
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;

    [Parameter]
    [SupplyParameterFromQuery(Name = "scrollTo")]
    public string? ScrollTo { get; set; }

    [CascadingParameter(Name = "Breakpoint")]
    protected Breakpoint CurrentBreakpoint { get; set; }
    private int _count = 0;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!string.IsNullOrWhiteSpace(ScrollTo))
        {
            await Task.Delay(1500);
            await JsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", ScrollTo);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private const string AnimationEntrance = "animate__animated animate__lightSpeedInLeft animate__delay-1s";
    private const string AnimationExit = "animate__animated animate__lightSpeedOutRight";

    private void OnClick()
    {
        _count++;
        if (_count > 3)
        {
            _count = 0;
        }
    }

    private bool _matrix = true;
    
    protected override async Task OnInitializedAsync()
    {
        AppState.ThemeChanged += OnNotify;
        await Matrix();
        await base.OnInitializedAsync();
    }

    private async Task Matrix()
    {
        await Task.Delay(1000);
        _matrix = false;
        StateHasChanged();
    }
    
    private async void OnNotify()
    {
        await InvokeAsync(StateHasChanged);
    }
    
    public ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
        return ValueTask.CompletedTask;
    }
}