using System.Threading.Tasks;
using BlazorWebCV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorWebCV.Components.Certifications;

public partial class Certifications
{
    [Inject] private IOptions<CertsModel> Certs { get; set; } = default!;
    private string _overlayImage = "";
}