using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using BlazorWebCV.Helpers;
using BlazorWebCV.Models;
using BlazorWebCV.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Projects
{
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] private IDialogService DialogService { get; set; }
    private List<ProjectModel> ProjectModels { get; set; } = ProjectHelper.GetProjects();
    private async Task Code(string name)
    {
        try
        {
            await JsRuntime.InvokeAsync<object>("open", ProjectModels.Single(i=>i.Title.Equals(name)).Repository, "_blank");
        }
        catch (Exception ex)
        {
            // ignored
        }
    }
    
    private async Task Click(string name)
    {
        var parameters = new DialogParameters();
        parameters.Add("Title", name);
        parameters.Add("ContentText", ProjectModels.Single(i=>i.Title.Equals(name)).PopupDescription);

        var options = new DialogOptions() {CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true};
        DialogService.Show<Dialog>("", parameters, options);
    }
}