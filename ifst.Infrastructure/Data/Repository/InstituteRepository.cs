using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class InstituteRepository : Repository<Institute>, IInstituteRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;


    public InstituteRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<IEnumerable<InstituteDto>> GetAllInstitutesAndProjects()
    {

        var institutes = await _context.Institute
            .Where(i => i.Confirmed)
            .ProjectTo<InstituteDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return institutes;
    }
}