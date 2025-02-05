using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components.Skills;

public partial class Skills
{
    [Inject] private IOptions<SkillsModel> SkillsModel { get; set; } = default!;
}