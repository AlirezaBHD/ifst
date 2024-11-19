using ifst.API.ifst.Infrastructure.Data;

namespace ifst.API.ifst.Application.Services;

public class GeneralServices
{
    private readonly ApplicationDbContext _context;

    public GeneralServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}