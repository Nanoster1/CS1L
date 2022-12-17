using CS1L.Shared.Models;

namespace CS1L.Core.Tests.Interfaces;

public interface ITestRepository
{
    Task<Test?> GetAsync(int id);
}
