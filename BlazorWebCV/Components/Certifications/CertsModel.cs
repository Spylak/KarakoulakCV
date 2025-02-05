using System.Collections.Generic;

namespace BlazorWebCV.Components.Certifications;

public class CertsModel
{
    public Dictionary<string, Dictionary<string, string>> Certs { get; set; } = [];
}