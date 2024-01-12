using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWebCV.Shared;

public partial class MainLayout : IBrowserViewportObserver, IAsyncDisposable
{ 
    [Inject] AppState AppState { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Inject] IBrowserViewportService BrowserViewportService { get; set; }
    
    private List<string> PageUris { get; set; }
    private string RightDrawerWidth { get; set; } = "500px";
    private Breakpoint CurrentBreakPoint { get; set; }
    protected override void OnInitialized()
    {
        AppState.ThemeChanged += OnNotify;
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await BrowserViewportService.SubscribeAsync(this, fireImmediately: true);
        }

        await base.OnAfterRenderAsync(firstRender);
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
        await BrowserViewportService.UnsubscribeAsync(this);
    }

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
    
    private void TabChoiceChanged(int index)
    {
        AppState.ActiveTabPanelIndex = index;
        switch (index)
        {
            case 0:
                NavigationManager.NavigateTo("");
                break;
            case 1:
                NavigationManager.NavigateTo(SectionModel.Projects);
                break;
            case 2:
                NavigationManager.NavigateTo(SectionModel.Certifications);
                break;
            case 3:
                NavigationManager.NavigateTo(SectionModel.Interests);
                break;
        }
    }

    public Guid Id { get; } = Guid.NewGuid();
}