using System.Collections.Generic;
using System.Dynamic;

namespace BlazorWebCV.Models;

public class SkillsModel
{
    public Dictionary<string,ExpandoObject> SoftSkills { get; set; }
    public Dictionary<string,ExpandoObject> ProgrammingSkills { get; set; }
}