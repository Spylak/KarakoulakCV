using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Inject] private IOptions<ProjectsModel> ProjectsModel { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] private IDialogService DialogService { get; set; }
    private async Task Code(string name)
    {
        await JsRuntime.InvokeAsync<object>("open", ProjectsModel.Value.Projects.Values.FirstOrDefault(i=>i["title"]!.Equals(name))!["repository"], "_blank");
    }
    
    private async Task Click(string name)
    {
        var parameters = new DialogParameters();
        parameters.Add("Title", name);
        parameters.Add("ContentText", ProjectsModel.Value.Projects.Values.FirstOrDefault(i=>i["title"]!.Equals(name))!["popupdescription"]);

        var options = new DialogOptions() {CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true};
        DialogService.Show<Dialog>("", parameters, options);
    }

}