using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.Services;
using BlazorWebCV.Services.IServices;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Shared.RightNavMenu;

public partial class RightNavMenu
{
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] private AppState AppState { get; set; } = null!;
    [Inject] private IGlobalFunctionService GlobalFunctionService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    private List<RightNavMenuItem> NavMenuItems { get; set; } = [];

    protected override void OnInitialized()
    {
        NavMenuItems =
        [
            new RightNavMenuItem
            {
                Text = "Profile",
                Section = SectionModel.Profile,
                Classes = "navMenuActive",
                Icon = Icons.Material.Filled.AssignmentInd
            },
            new RightNavMenuItem
            {
                Text = "Experience",
                Section = SectionModel.Experience,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Work
            },
            new RightNavMenuItem
            {
                Text = "Toolkit",
                Section = SectionModel.Tools,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.HomeRepairService
            },
            new RightNavMenuItem
            {
                Text = "Skills",
                Section = SectionModel.Skills,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Extension
            },
            new RightNavMenuItem
            {
                Text = "In Progress",
                Section = SectionModel.InProgress,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Downloading
            },
            new RightNavMenuItem
            {
                Text = $"Copyright @{DateTime.Now.Year}",
                Section = SectionModel.Copyright,
                Classes = "navMenuInActive",
                Icon = ""
            }
        ];
    }

    private async Task ScrollTo(string section)
    {
        await JsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", section);
    }
}