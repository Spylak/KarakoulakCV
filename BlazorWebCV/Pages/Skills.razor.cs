using System;
using System.Threading.Tasks;
using BlazorPro.BlazorSize;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using Breakpoints = BlazorPro.BlazorSize.Breakpoints;

namespace BlazorWebCV.Pages;

public partial class Skills :IDisposable
{
    [Inject] private IOptions<SkillsModel> SkillsModel { get; set; }
    [Inject] private IResizeListener _listener { get; set; }
    [Inject] private IJSRuntime _JsRuntime { get; set; }
    [CascadingParameter(Name = "theme")]
    protected string theme { get; set; }
    bool IsXSmallDown = false;
    private string hidden = "visibility:visible";
    BrowserWindowSize browser = new BrowserWindowSize();
    public Typo typo { get; set; }
    protected override async void OnInitialized()
    {
        browser = await _listener.GetBrowserWindowSize();
        if (browser.Width < 600)
        {
            typo = Typo.body1;
            hidden = "visibility:hidden";
        }
        else
        {
            typo = Typo.h5;
        }
        await Visible();

        StateHasChanged();
    }

    private bool showList { get; set; } = false;
    private string gridLoad ="hidden";
    public async Task Visible()
    {
        await Task.Delay(1000);
        gridLoad = "visible";
    }
    private void ShowList()
    {
        showList = !showList;
    }
    protected override void OnAfterRender(bool firstRender)
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
        if (IsXSmallDown == true)
        {
            typo = Typo.body1;
            hidden = "visibility:hidden";
        }else
        {
            hidden = "visibility:visible";
            typo = Typo.h5;

        }
        StateHasChanged();
    }
}