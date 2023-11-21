using System.Threading.Tasks;

namespace BlazorWebCV.Services.IServices;

public interface IGlobalFunctionService
{
    Task ConsoleLog<T>(T obj) where T : class;
}