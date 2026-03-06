using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;

namespace BlazorWebCV.Components.Tools;

public partial class Tools
{
    [Inject] private IOptions<ToolsModel> ToolsModel { get; set; } = default!;

    protected override void OnInitialized()
    {
        foreach (var tool in ToolsModel.Value.Tools.Values)
        {
            if (tool.ContainsKey("icon") && tool["icon"].StartsWith("Icons.Material.Filled."))
            {
                var iconName = tool["icon"].Replace("Icons.Material.Filled.", "");
                var fieldInfo = typeof(Icons.Material.Filled).GetField(iconName, BindingFlags.Public | BindingFlags.Static);
                if (fieldInfo != null)
                {
                    tool["icon"] = fieldInfo.GetValue(null)?.ToString() ?? tool["icon"];
                }
            }
        }
    }
}