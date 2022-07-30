using System.Collections.Generic;
using System.Dynamic;

namespace BlazorWebCV.Models;

public class SkillsModel
{
    public Dictionary<string,Dictionary<string,string>> SoftSkills { get; set; }
    public Dictionary<string,Dictionary<string,string>> ProgrammingSkills { get; set; }
}