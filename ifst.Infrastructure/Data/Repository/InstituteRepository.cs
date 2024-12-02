using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;



public class InstituteRepository : Repository<Institute>,IInstituteRepository
{
    private readonly ApplicationDbContext _context;
    
    public InstituteRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}