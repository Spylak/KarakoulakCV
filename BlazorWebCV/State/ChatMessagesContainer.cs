using System.Collections.Generic;
using BlazorWebCV.Models;

namespace BlazorWebCV.State;

public class ChatMessagesContainer
{
    public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>()
    {
        new ChatMessage()
        {
            Order = 0,
            Message = "robot&&Greetings, welcome to my website!\n" +
                      "Feel free to take a look around.\n" +
                      "Type Help for available commands."
        }
    };
}