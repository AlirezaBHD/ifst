using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class ProjectRepository: Repository<Project> , IProjectRepository
{
    private readonly ApplicationDbContext _context;
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}