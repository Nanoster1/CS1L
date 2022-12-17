using CS1L.Core.Tests.Interfaces;
using CS1L.Shared.Models.Tests;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Data.Repositories;

public class TestRepository : ITestRepository
{
    private readonly TestsContext _context;

    public TestRepository(TestsContext context)
    {
        _context = context;
    }

    public async Task<Test?> GetAsync(int id)
    {
        return await _context.Tests.FirstOrDefaultAsync(x => x.Id == id);
    }
}
