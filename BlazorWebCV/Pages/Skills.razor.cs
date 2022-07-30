using System;
using System.Threading.Tasks;
using BlazorPro.BlazorSize;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using Breakpoints = BlazorPro.BlazorSize.Breakpoints;

namespace BlazorWebCV.Pages;

public partial class Skills
{
    [Inject] private IOptions<SkillsModel> SkillsModel { get; set; }
    [Inject] private IResizeListener _listener { get; set; }
    [Inject] private IJSRuntime _JsRuntime { get; set; }
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    protected override async void OnInitialized()
    {
        await Visible();
        StateHasChanged();
    }

    private bool showList { get; set; } = false;
    private string gridLoad ="hidden";
    public async Task Visible()
    {
        await Task.Delay(1000);
        gridLoad = "visible";
    }
    private void ShowList()
    {
        showList = !showList;
    }
}