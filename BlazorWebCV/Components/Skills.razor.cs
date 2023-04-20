using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components;

public partial class Skills
{
    [Inject] private IOptions<SkillsModel> SkillsModel { get; set; }

    private bool showList { get; set; } = false;
    private void ShowList()
    {
        showList = !showList;
    }
}