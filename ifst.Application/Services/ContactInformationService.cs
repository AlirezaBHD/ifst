using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class ContactInformationService : IContactInformationService
{
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;
    private readonly IContactInformationRepository _contactInformationRepository;

    public ContactInformationService(IMapper mapper, IGeneralServices generalServices,
        IContactInformationRepository contactInformationRepository)
    {
        _mapper = mapper;
        _generalServices = generalServices;
        _contactInformationRepository = contactInformationRepository;
    }

    public async Task UpdateContactInformation(ContactInformationDto dto)
    {
        var contactInfo = await _contactInformationRepository.GetFirstOrNullAsync();

        if (contactInfo == null)
        {
            contactInfo = _mapper.Map<ContactInformation>(dto);
            await _contactInformationRepository.AddAsync(contactInfo);
        }
        else
        {
            contactInfo = _mapper.Map(dto, contactInfo);
            _contactInformationRepository.Update(contactInfo);
        }

        await _generalServices.SaveAsync();
    }
}