using Microsoft.AspNetCore.Components;

namespace BlazorWebCV.Components.Chat;

public partial class Chat
{
    [Inject] ChatState ChatState { get; set; }
}