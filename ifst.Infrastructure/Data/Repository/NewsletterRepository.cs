using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class NewsletterRepository: Repository<Newsletter> , INewsletterRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    
    public NewsletterRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}