using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorWebCV.Pages;

public partial class Index
{
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    [CascadingParameter(Name = "Breakpoint")]
    protected Breakpoint CurrentBreakpoint { get; set; }
    [Inject]
    private IJSRuntime jsRuntime { get; set; }
    private  string color { get; set; }
    private int count = 0;
    protected override void OnParametersSet()
    {
        color = theme == "dark" ? "black" : "#bfbbbb";
        base.OnParametersSet();
    }
    private string AnimationEntrance = "animate__animated animate__lightSpeedInLeft animate__delay-1s";
    private string AnimationExit = "animate__animated animate__lightSpeedOutRight";

    private List<string> Messages = new List<string>()
    {
        "robot&&Greetings, welcome to my website. Feel free to take a look around.Type Help for available commands."
    };

    private class Input
    {
        public string Value { get; set; }
    }
    private Input input = new Input();
    private string commands;

    private Dictionary<string, string> AutomatedAnswers = new Dictionary<string, string>()
    {
        {"toolkit", "In this section you can take a look at which technologies, tools, methodologies and patterns I am using."},
        {"skills", "In this section you can take a look on the skills I currently possess."},
        {"interests", "I present some of the interests I have that aren't directly related to the work environment."},
        {"profile", "This is a brief overview of who I am."},
        {"copyright", "Here is the link to the source code of this project."},
        {"experience", "A timeline of my experience in my adulthood life."},
        {"projects", "Projects I am currently part of, developing or personal projects for practise."},
        {"inprogress", "Here are the fields I am currently researching."},
        {"contact", "Here are my contact details as well as a contact form prompting you to your accustomed email client."},
        {"certifications", "Here are the certifications I have acquired in my journey."}
    };

    private async Task Help()
    {
        Messages.Add($"robot&&Available commands: {commands}");
    }

    private async Task Send(EditContext context)
    {
        if (input.Value is not null)
        {
            Messages.Add($"user&&{input.Value}");
            var value = input.Value.ToLower();
            if (AutomatedAnswers.Keys.ToList().Contains(value))
            {
                Messages.Add($"robot&&{AutomatedAnswers[value]}");
            }
            else if (value=="help")
            {
                Messages.Add($"robot&&{commands}");
            }
            else
            {
                Messages.Add($"robot&&I don't recognize this command. Available commands: {commands}");
            }
        }
        else
        {
            Messages.Add($"robot&&No command was given. Available commands: {commands}");
        }
        await Task.Yield();
        input = new Input();
        StateHasChanged();
    }
    private async Task OnClick()
    {
        count++;
        if (count > 3)
        {
            count = 0;
        }
    }
    private bool matrix = true;

    protected override async void OnInitialized()
    {
        foreach (var command in AutomatedAnswers.Keys)
        {
            commands += command + ", ";
        }
        commands = commands.Substring(0, commands.LastIndexOf(','));
        Matrix();
        base.OnInitialized();
    }

    private async Task Matrix()
    {
        await Task.Delay(1000);
        matrix = false;
        StateHasChanged();
    }
}