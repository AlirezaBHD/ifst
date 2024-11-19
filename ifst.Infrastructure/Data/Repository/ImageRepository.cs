using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class ImageRepository : Repository<Image>,IImageRepository
{
    private readonly ApplicationDbContext _context;
    
    public ImageRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}