using System;
using MudBlazor;

namespace BlazorWebCV.State;

public class AppState
{
    public string Theme { get; private set; } = AppConstants.DarkTheme;
    public bool LeftNavMenuOpened { get; set; } = true;
    public bool RightNavMenuOpened { get; set; } = false;
    public int ActiveTabPanelIndex { get; set; } = 0;
    public string BackgroundColor { get; set; } = "black";
    public Color ButtonColor { get; set; } = Color.Inherit;
    private static readonly MudTheme DarkTheme = new MudTheme()
    {
        Palette = new Palette()
        {
            Black = "#27272f",
            Background = "#32333d",
            BackgroundGrey = "#27272f",
            Surface = "#373740",
            DrawerBackground = "#27272f",
            DrawerText = "rgba(93, 255, 0, 1)",
            DrawerIcon = "rgba(93, 255, 0, 1)",
            AppbarBackground = "#27272f",
            AppbarText = "rgba(93, 255, 0, 1)",
            TextPrimary = "rgba(93, 255, 0, 1)",
            TextSecondary = "rgba(93, 255, 0, 1)",
            ActionDefault = "#adadb1",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "rgba(93, 255, 0, 0.4)",
            DividerLight = "rgba(93, 255, 0, 0.4)",
            TableLines = "rgba(93, 255, 0, 1)",
            LinesDefault = "rgba(93, 255, 0, 1)",
            LinesInputs = "rgba(93, 255, 0, 0.4)",
            TextDisabled = "rgba(255,255,255, 0.2)",
            Primary = "#272c34"
        }
    };
    
    private static readonly MudTheme DefaultTheme = new MudTheme()
    {
        Palette = new Palette()
        {
            Black = "#272c34",
            AppbarBackground = "#32333d",
            Primary = "#272c34"
        }
    };
    
    public MudTheme CurrentTheme { get; set; } = DarkTheme;
    public event Action? ThemeChanged;

    public void NotifyThemeChanged() => ThemeChanged?.Invoke();

    public void ToggleLeftNavMenu()
    {
        LeftNavMenuOpened = !LeftNavMenuOpened;
    }
    
    public void ToggleRightNavMenu()
    {
        RightNavMenuOpened = !RightNavMenuOpened;
    }
    
    public void ToggleTheme()
    {
        switch (Theme)
        {
            case AppConstants.DarkTheme:
                Theme = AppConstants.LightTheme;
                CurrentTheme = DefaultTheme;
                BackgroundColor = "#bfbbbb";
                break;
            case AppConstants.LightTheme:
                Theme = AppConstants.DarkTheme;
                CurrentTheme = DarkTheme;
                BackgroundColor = "black";
                break;
        }
        ButtonColor = ButtonColor == Color.Dark ? Color.Inherit : Color.Dark;
        NotifyThemeChanged();
    }
}