using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorWebCV.Enums;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Shared.LeftNavMenu;

public partial class LeftNavMenu : IAsyncDisposable
{
    [Parameter]
    public Breakpoint CurrentBreakPoint { get; set; }
    [Inject] AppState AppState { get; set; }
    public string MudAvatarDimensions { get; set; }
    public Typo TitleTypo { get; set; }
    private List<LeftNavMenuItem> NavMenuItems { get; set; }
    protected override void OnParametersSet()
    {
        if (CurrentBreakPoint == Breakpoint.Sm || CurrentBreakPoint == Breakpoint.Xs)
        {
            MudAvatarDimensions = "50vw";
            TitleTypo = Typo.h6;
        }
        else
        {
            MudAvatarDimensions = "20vw";
            TitleTypo = Typo.h3;
        }
    }
    
    private async void OnNotify()
    {
        await InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }
    
    protected override void OnInitialized()
    {
        NavMenuItems = new()
        {
            new()
            {
                Text = $"Copyright @{DateTime.Now.Year}",
                Section = SectionModel.Copyright,
                Classes = "navMenuInActive",
                Icon = ""
            },
        };
        AppState.ThemeChanged += OnNotify;
        base.OnInitialized();
    }

    private async Task OnClick(string section)
    {
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", section);
    }

    private async Task OnSocialClick(SocialMedia socialMedia)
    {
        switch (socialMedia)
        {
            case SocialMedia.Github:
                await _jsRuntime.InvokeVoidAsync("GlobalFunctions.NewTab", "https://github.com/Spylak");
                break;
            case SocialMedia.LinkedIn:
                await _jsRuntime.InvokeVoidAsync("GlobalFunctions.NewTab", "https://www.linkedin.com/in/spyridon-karakoulak-4267201b9/");
                break;
            case SocialMedia.Instagram:
                await _jsRuntime.InvokeVoidAsync("GlobalFunctions.NewTab", "https://www.instagram.com/karakouluck/");
                break;
        }
    }
    
    public async ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
    }
}