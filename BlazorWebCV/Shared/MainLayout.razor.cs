using System;
using System.Threading.Tasks;
using BlazorWebCV.State;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Services;

namespace BlazorWebCV.Shared;

public partial class MainLayout
{
    [Inject] private AppState AppState { get; set; } = null!;
    [Inject] NavigationManager NavigationManager { get; set; } = null!;
    [Inject] IBrowserViewportService BrowserViewportService { get; set; } = null!;
    protected override void OnInitialized()
    {
        AppState.ThemeChanged += OnNotify;
        AppState.CurrentPage = NavigationManager.Uri.Split("/")[^1];
        base.OnInitialized();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await BrowserViewportService.SubscribeAsync(this, fireImmediately: true);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    public async ValueTask DisposeAsync()
    {
        AppState.ThemeChanged -= OnNotify;
        await BrowserViewportService.UnsubscribeAsync(this);
    }

    Guid IBrowserViewportObserver.Id { get; } = Guid.NewGuid();

    ResizeOptions IBrowserViewportObserver.ResizeOptions { get; } = new()
    {
        ReportRate = 250,
        NotifyOnBreakpointOnly = true
    };

    Task IBrowserViewportObserver.NotifyBrowserViewportChangeAsync(BrowserViewportEventArgs browserViewportEventArgs)
    {
        AppState.CurrentBreakPoint = browserViewportEventArgs.Breakpoint;
        return InvokeAsync(StateHasChanged);
    }
    
    private async void OnNotify()
    {
        await InvokeAsync(StateHasChanged);
    }
    
    private void ListItemClicked(string navTo)
    {
        AppState.CurrentPage = navTo;
        NavigationManager.NavigateTo(navTo);
    }

    private string IsActive(string page)
    {
         return AppState.CurrentPage == page ? "background-color: gray": "";
    }
    
    public Guid Id { get; } = Guid.NewGuid();
    private readonly MudTheme _theme = new()
    {
        PaletteLight = new PaletteLight
        {
            Black = "#272c34",
            AppbarBackground = "#32333d",
            Primary = "#272c34",
            PrimaryDarken = "#1976D2",
            PrimaryLighten = "#42A5F5",
            Secondary = "#ff4081",
            SecondaryDarken = "#f50057",
            SecondaryLighten = "#ff80ab",
            Background = "#F5F5F5",
            Surface = "#FFFFFF",
            DrawerBackground = "#FFFFFF",
            DrawerText = "rgba(0,0,0,0.87)",
            AppbarText = "#FFFFFF",
            TextPrimary = "rgba(0,0,0,0.87)",
            TextSecondary = "rgba(0,0,0,0.60)",
            ActionDefault = "#757575",
            ActionDisabled = "rgba(0,0,0,0.26)",
            ActionDisabledBackground = "rgba(0,0,0,0.12)",
            Error = "#FF5252",
            Success = "#4CAF50",
            Warning = "#FFC107",
            Info = "#2196F3",
        },
        PaletteDark = new PaletteDark
        {
            Black = "#27272f",
            Background = "#32333d",
            BackgroundGray = "#27272f",
            Surface = "#373740",
            DrawerBackground = "#27272f",
            DrawerText = "#d3d3d3",
            DrawerIcon = "#d3d3d3",
            AppbarBackground = "#27272f",
            AppbarText = "#d3d3d3",
            TextPrimary = "#d3d3d3",
            TextSecondary = "#d3d3d3",
            ActionDefault = "#adadb1",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "#d3d3d3",
            DividerLight = "#d3d3d3",
            TableLines = "#d3d3d3",
            LinesDefault = "#d3d3d3",
            LinesInputs = "#d3d3d3",
            TextDisabled = "rgba(255,255,255, 0.2)",
            Primary = "#272c34"
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = new[] { "Roboto", "Helvetica", "Arial", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = ".00938em"
            },
            H1 = new H1
            {
                FontSize = "6rem",
                FontWeight = 300,
                LineHeight = 1.167,
                LetterSpacing = "-.01562em"
            },
            H2 = new H2
            {
                FontSize = "3.75rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.00833em"
            },
            Button = new Button
            {
                FontSize = ".875rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = ".02857em",
                TextTransform = "uppercase"
            }
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "4px",
            DrawerWidthLeft = "500px"
        },
        Shadows = new Shadow(),
        ZIndex = new ZIndex()
    };
}