using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components.Experience;


public partial class Experience
{
    [Inject] private IOptions<ExperienceModel> ExperienceModel { get; set; }
}