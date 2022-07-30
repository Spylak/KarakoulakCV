using System.Collections.Generic;
using System.Dynamic;

namespace BlazorWebCV.Models;

public class ProjectsModel
{
    public Dictionary<string,Dictionary<string,string>> Projects { get; set; }
}