using System;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Pages;

public partial class Experience
{
    [Inject] private IOptions<ExperienceModel> ExperienceModel { get; set; }
}