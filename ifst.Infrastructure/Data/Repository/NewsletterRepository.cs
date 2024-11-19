using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class NewsletterRepository: Repository<Newsletter> , INewsletterRepository
{
    private readonly ApplicationDbContext _context;
    
    public NewsletterRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}