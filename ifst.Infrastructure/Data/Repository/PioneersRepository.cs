using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class PioneersRepository : Repository<Pioneers> , IPioneersRepository
{
    private readonly ApplicationDbContext _context;
    public PioneersRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}