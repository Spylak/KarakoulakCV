using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Pages;

public partial class Certifications
{
    [Inject] private IOptions<CertsModel> Certs { get; set; }
    private int count = 0;
    private string AnimationEntrance = "animate__animated animate__rotateInDownLeft";
    private string AnimationExit = "animate__animated animate__rotateOutUpLeft";
    
    private async Task OnClick()
    {
        count++;
        if (count > Certs.Value.Certs.Values.Count-1)
        {
            count = 0;
        }
    }
}