using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
namespace BlazorWebCV.Components;


public partial class Experience
{
    [Inject] private IOptions<ExperienceModel> ExperienceModel { get; set; }
}