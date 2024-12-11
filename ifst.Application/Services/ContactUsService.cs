using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Services;

public class ContactUsService : IContactUsService

{
    private readonly IMapper _mapper;
    private readonly IGeneralServices<ContactUs> _generalServices;
    private readonly IContactUsRepository _contactUsRepository;


    public ContactUsService(IContactUsRepository contactUsRepository, IGeneralServices<ContactUs> generalServices, IMapper mapper)
    {
        _contactUsRepository = contactUsRepository;
        _generalServices = generalServices;
        _mapper = mapper;
    }

    public async Task AddContactUsAsync(CreateContactUs contactUsDto)
    {
        var contactObject = _mapper.Map<ContactUs>(contactUsDto);

        await _contactUsRepository.AddAsync(contactObject);
        await _contactUsRepository.SaveAsync();
        
    }

    //Check
    public async Task<ContactUs> GetContactUsByIdAsync(GetObjectByIdDto allContactUsDto)
    {
        var contactUsObj = await _contactUsRepository.GetByIdAsync(allContactUsDto.Id);
        return contactUsObj;
    }

    public async Task<PaginatedResult<ContactUs>> FilteredPaginatedContactUsList(FilterAndSortPaginatedOptions options)
    {
        var result = await _contactUsRepository.GetFilteredAndSortedPaginated<ContactUs>(options);
        return result;
    }
}