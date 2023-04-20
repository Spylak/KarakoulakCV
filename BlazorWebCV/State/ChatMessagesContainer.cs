using System.Collections.Generic;

namespace BlazorWebCV.State;

public class ChatMessagesContainer
{
    public List<string> ChatMessages { get; set; } = new List<string>()
    {
        "robot&&Greetings, welcome to my website!\n" +
            "Feel free to take a look around.\n" +
            "Type Help for available commands."
    };
}