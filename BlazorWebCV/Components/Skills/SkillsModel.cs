using System.Collections.Generic;

namespace BlazorWebCV.Components.Skills;

public class SkillsModel
{
    public Dictionary<string,Dictionary<string,string>> SoftSkills { get; set; }
    public Dictionary<string,Dictionary<string,string>> ProgrammingSkills { get; set; }
}