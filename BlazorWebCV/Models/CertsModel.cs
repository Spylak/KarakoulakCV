using System.Collections.Generic;

namespace BlazorWebCV.Models;

public class CertsModel
{
    public Dictionary<string,Dictionary<string,string>> Certs { get; set; }
}