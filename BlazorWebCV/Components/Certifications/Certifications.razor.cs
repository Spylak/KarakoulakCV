using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components.Certifications;

public partial class Certifications
{
    [Inject] private IOptions<CertsModel> Certs { get; set; }
    private string overlayImage = "";
    private bool isVisible;
    private async Task OnClick(string image)
    {
        isVisible = true;
        overlayImage = image;
        StateHasChanged();
    }
}