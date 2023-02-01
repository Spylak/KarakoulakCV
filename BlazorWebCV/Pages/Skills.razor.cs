using System;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Skills
{
    [Inject] private IOptions<SkillsModel> SkillsModel { get; set; }

    private bool showList { get; set; } = false;
    private void ShowList()
    {
        showList = !showList;
    }
}