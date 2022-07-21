using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using Breakpoints = BlazorPro.BlazorSize.Breakpoints;

namespace BlazorWebCV.Pages;

public partial class Index
{
    [CascadingParameter(Name = "theme")]
    [Inject]
    private IJSRuntime jsRuntime { get; set; }
    [Inject] private IResizeListener _listener { get; set; }
    protected string theme { get; set; }
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
    BrowserWindowSize browser = new BrowserWindowSize();
    bool IsXSmallDown = false;
    private string hidden = "visibility:visible";
    private int phoneMargin = 0;
    public Typo typo { get; set; }
    private int gridOne = 6;
    private int gridTwo = 6;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
    // Subscribe to the OnResized event. This will do work when the browser is resized.
            _listener.OnResized += WindowResized;
        }
    }

    public void Dispose()
    {
    // Always use IDisposable in your component to unsubscribe from the event.
    // Be a good citizen and leave things how you found them. 
    // This way event handlers aren't called when nobody is listening.
        _listener.OnResized -= WindowResized;
    }

    async void WindowResized(object _, BrowserWindowSize window)
    {
    // Get the browsers's width / height
        browser = window;

    // Check a media query to see if it was matched. We can do this at any time, but it's best to check on each resize
        IsXSmallDown = await _listener.MatchMedia(Breakpoints.SmallDown);

    // We're outside of the component's lifecycle, be sure to let it know it has to re-render.
        if (IsXSmallDown)
        {
            typo = Typo.body1;
            hidden = "visibility:hidden";
            phoneMargin = 30;
            gridOne = 12;
            gridTwo = 0;
        }
        else
        {
            hidden = "visibility:visible";
            phoneMargin = 0;
            typo = Typo.h5;
            gridOne = 6;
            gridTwo = 6;
        }
        StateHasChanged();
    }

    protected override async void OnInitialized()
    {
        browser = await _listener.GetBrowserWindowSize();
        if (browser.Width < 600)
        {
            typo = Typo.body1;
            gridOne = 12;
            gridTwo = 0;
            hidden = "visibility:hidden";
            phoneMargin = 30;
        }
        else
        {
            typo = Typo.h5;
        }
        StateHasChanged();
        foreach (var command in AutomatedAnswers.Keys)
        {
            commands += command + ", ";
        }
        commands = commands.Substring(0, commands.LastIndexOf(','));
        browser = await _listener.GetBrowserWindowSize();
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