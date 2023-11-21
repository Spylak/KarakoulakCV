using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWebCV.Shared;

public partial class MainLayout : IBrowserViewportObserver, IAsyncDisposable
{ 
    [Inject] AppState AppState { get; set; }
    [Inject] IBrowserViewportService BrowserViewportService { get; set; }
    private string RightDrawerWidth { get; set; } = "500px";
    private Breakpoint CurrentBreakPoint { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await BrowserViewportService.SubscribeAsync(this, fireImmediately: true);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    public async ValueTask DisposeAsync() => await BrowserViewportService.UnsubscribeAsync(this);

    public Task NotifyBrowserViewportChangeAsync(BrowserViewportEventArgs browserViewportEventArgs)
    {
        CurrentBreakPoint = browserViewportEventArgs.Breakpoint;
        if (CurrentBreakPoint == Breakpoint.Sm || CurrentBreakPoint == Breakpoint.Xs)
        {
            RightDrawerWidth = "95vw";
        }
        else
        {
            RightDrawerWidth = "35vw";
        }
        return InvokeAsync(StateHasChanged);
    }

    public Guid Id { get; } = Guid.NewGuid();
}