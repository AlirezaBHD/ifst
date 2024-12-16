using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class AparatVideoRepository: Repository<AparatVideo>, IAparatVideoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AparatVideoRepository(ApplicationDbContext context, IMapper mapper) : base(context , mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}