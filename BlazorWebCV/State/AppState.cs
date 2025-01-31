using System;
using MudBlazor;

namespace BlazorWebCV.State;

public class AppState
{
    public string Theme { get; private set; } = AppConstants.DarkTheme;
    public bool LeftNavMenuOpened { get; set; } = true;
    public bool RightNavMenuOpened { get; set; } = false;
    public string CurrentPage { get; set; } = "";
    public string BackgroundColor { get; set; } = "black";
    public Color ButtonColor { get; set; } = Color.Inherit;
    
    public event Action? ThemeChanged;    
    public event Action? BreakpointChanged;
    private Breakpoint _currentBreakpoint = Breakpoint.Xs;

    public Breakpoint CurrentBreakPoint
    {
        get => _currentBreakpoint;
        set
        {
            _currentBreakpoint = value;
            NotifyBreakpointChanged();
        }
    }

    public void NotifyThemeChanged() => ThemeChanged?.Invoke();
    public void NotifyBreakpointChanged() => BreakpointChanged?.Invoke();

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
                BackgroundColor = "#bfbbbb";
                break;
            case AppConstants.LightTheme:
                Theme = AppConstants.DarkTheme;
                BackgroundColor = "black";
                break;
        }
        ButtonColor = ButtonColor == Color.Dark ? Color.Inherit : Color.Dark;
        NotifyThemeChanged();
    }
}