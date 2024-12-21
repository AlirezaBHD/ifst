using AutoMapper;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class UpdateProjectRepository: Repository<UpdateProject> , IUpdateProjectRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProjectRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UpdateProject> UpdateProjectObject(int id)
    {
        IQueryable<UpdateProject> query = _context.Set<UpdateProject>();
        query=query.Include(up => up.Project);
        var obj = await query.FirstOrDefaultAsync(up => up.Id == id);
        obj.ThrowIfNull("بروزرسانی پروژه");
        return obj;
    }
    
}