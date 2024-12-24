using AutoMapper;
using AutoMapper.QueryableExtensions;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.StudentDto;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class StudentRepository: Repository<Student> , IStudentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PaginatedResult<StudentListDto>> SearchStudentsAsync(SearchStudentDto searchOptions)
    {
        var query = _context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchOptions.Name))
            query = query.Where(s => s.Name.Contains(searchOptions.Name));

        if (!string.IsNullOrWhiteSpace(searchOptions.LastName))
            query = query.Where(s => s.LastName.Contains(searchOptions.LastName));

        if (!string.IsNullOrWhiteSpace(searchOptions.NationalCode))
            query = query.Where(s => s.NationalCode == searchOptions.NationalCode);

        if (!string.IsNullOrWhiteSpace(searchOptions.StudentId))
            query = query.Where(s => s.StudentId == searchOptions.StudentId);
        
        var totalCount = await query.CountAsync();
        var students = await query
            .Skip((searchOptions.Page - 1) * searchOptions.PageSize)
            .Take(searchOptions.PageSize)
            .ProjectTo<StudentListDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        var result = new PaginatedResult<StudentListDto>
        {
            Items = students,
            TotalCount = totalCount,
            PageNumber = searchOptions.Page,
            PageSize = searchOptions.PageSize
        };
        return result;
    }

}