using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Index : IAsyncDisposable
{
    [Inject] private AppState AppState { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "scrollTo")]
    public string? ScrollTo { get; set; }

    [CascadingParameter(Name = "Breakpoint")]
    protected Breakpoint CurrentBreakpoint { get; set; }

    private string ImageStyle { get; set; }
    private int _count = 0;

    protected override async Task OnParametersSetAsync()
    {
        ImageStyle =
            (CurrentBreakpoint.Equals(Breakpoint.Xs) ? "width: 100%;height: 50vh" : "width: 100%;height: 70vh;") +
            "border-radius: 5px";
        await base.OnParametersSetAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!string.IsNullOrWhiteSpace(ScrollTo))
        {
            await Task.Delay(1500);
            await JsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", ScrollTo);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private string AnimationEntrance = "animate__animated animate__lightSpeedInLeft animate__delay-1s";
    private string AnimationExit = "animate__animated animate__lightSpeedOutRight";

    private async Task OnClick()
    {
        _count++;
        if (_count > 3)
        {
            _count = 0;
        }
    }

    private bool matrix = true;
    
    protected override async Task OnInitializedAsync()
    {
        AppState.ThemeChanged += OnNotify;
        await Matrix();
        base.OnInitialized();
    }

    private async Task Matrix()
    {
        await Task.Delay(1000);
        matrix = false;
        StateHasChanged();
    }
    
    private async void OnNotify()
    {
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