using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWebCV.Models;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebCV.Components.Chat;

public partial class ChatMessages
{
    [Inject] private AppState AppState { get; set; } = null!;
    [Parameter] public List<ChatMessage> Messages { get; set; } = [];
    [Parameter] public string ChatIconColor { get; set; } = string.Empty;
    [Parameter] public EventCallback<List<ChatMessage>> MessagesChanged { get; set; }
    private class Input
    {
        public string? Value { get; set; }
    }
    private Input _input = new Input();
    private string Commands { get; set; } = "";

    private Dictionary<string, string> _automatedAnswers = new Dictionary<string, string>()
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
    
    protected override void OnInitialized()
    {
        StringBuilder commandsBuilder = new StringBuilder();
        foreach (var command in _automatedAnswers.Keys)
        {
            commandsBuilder.Append(command).Append(", ");
        }
        Commands = commandsBuilder.ToString().TrimEnd(',',' ');
        base.OnInitialized();
    }
    private void Help()
    {
        Messages.Add(new ChatMessage(Messages.Count+1, $"robot&&Available commands: {Commands}"));
    }

    private async Task Send(EditContext context)
    {
        if (_input.Value is not null)
        {
            Messages.Add(new ChatMessage(Messages.Count+1,$"user&&{_input.Value}"));
            var value = _input.Value.ToLower().Trim();
            if (_automatedAnswers.Keys.ToList().Contains(value))
            {
                Messages.Add(new ChatMessage(Messages.Count+1, $"robot&&{_automatedAnswers[value]}"));
            }
            else if (value=="help")
            {
                Messages.Add(new ChatMessage(Messages.Count+1,$"robot&&{Commands}"));
            }
            else
            {
                Messages.Add(new ChatMessage(Messages.Count+1,"robot&&I don't recognize this command. Type help for available commands."));
            }
        }
        else
        {
            Messages.Add(new ChatMessage(Messages.Count+1,$"robot&&No command was given. Available commands: {Commands}"));
        }
        await Task.Yield();
        _input = new Input();
        StateHasChanged();
    }
}