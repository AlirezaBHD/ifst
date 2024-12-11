﻿using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class PioneersRepository : Repository<Pioneers> , IPioneersRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PioneersRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}