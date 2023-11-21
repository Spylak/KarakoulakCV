using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Shared.RightNavMenu;

public partial class RightNavMenu
{
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] private AppState AppState { get; set; }
    private List<RightNavMenuItem> NavMenuItems { get; set; } 
    protected override void OnInitialized()
    {
        NavMenuItems = new ()
        {
            new ()
            {
                Text = "Profile",
                Section = SectionModel.Profile,
                Classes = "navMenuActive",
                Icon = Icons.Material.Filled.AssignmentInd
            },
            new ()
            {
                Text = "Experience",
                Section = SectionModel.Experience,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Work
            },
            new ()
            {
                Text = "Projects",
                Section = SectionModel.Projects,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Dns
            },
            new ()
            {
                Text = "Toolkit",
                Section = SectionModel.Tools,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.HomeRepairService
            },
            new ()
            {
                Text = "Skills",
                Section = SectionModel.Skills,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Extension
            },
            new ()
            {
                Text = "Certifications",
                Section = SectionModel.Certifications,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Task
            },
            new ()
            {
                Text = "Interests",
                Section = SectionModel.Interests,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Interests
            },
            new ()
            {
                Text = "In Progress",
                Section = SectionModel.InProgress,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.Downloading
            },
            new ()
            {
                Text = "Contact",
                Section = SectionModel.Contact,
                Classes = "navMenuInActive",
                Icon = Icons.Material.Filled.PermPhoneMsg
            },
            new ()
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
        await JsRuntime.InvokeVoidAsync("blazorExtensions.ScrollToElementId", section);
    }
}