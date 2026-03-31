using System.Threading.Tasks;
using BlazorWebCV.Services.IServices;
using Microsoft.JSInterop;

namespace BlazorWebCV.Services;

public class GlobalFunctionService : IGlobalFunctionService
{
    private readonly IJSRuntime _jsRuntime;
    public GlobalFunctionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ConsoleLog<T>(T obj)
    {
        await _jsRuntime.InvokeVoidAsync("GlobalFunctions.Log", obj);
    }

    public async Task DownloadCvPdf()
    {
        await _jsRuntime.InvokeVoidAsync("GlobalFunctions.DownloadCvPdf");
    }
}