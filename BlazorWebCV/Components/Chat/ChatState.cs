using System.Collections.Generic;

namespace BlazorWebCV.Components.Chat;

public class ChatState
{
    public bool IsChatOpen
    {
        get { return Visibility == "hidden"; }
        set { Visibility = value ? "hidden" : "visible"; }
    }
    public string Visibility { get; set; } = "hidden";
    public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>()
    {
        new ChatMessage(0, "robot&&Greetings, welcome to my website!\n" +
                      "Feel free to take a look around.\n" +
                      "Type Help for available commands.")
    };
}