using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Shared.LeftNavMenu;

public partial class LeftNavMenu
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
    }

    private async Task OnClick(string section)
    {
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", section);
    }
}