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
    private readonly FileService _fileService;
    private readonly IGeneralServices _generalServices;
    private readonly IPioneersRepository _pioneersRepository;
    private readonly IContactInformationRepository _contactInformationRepository;

    public ContactInformationService(IPioneersRepository pioneersRepository, IMapper mapper,
        FileService fileService, IGeneralServices generalServices)
    {
        _pioneersRepository = pioneersRepository;
        _mapper = mapper;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    public async Task UpdateContactInformation(ContactInformationDto dto)
    {
        var contactInfo = await _contactInformationRepository.GetByIdFirstOrDefaultAsync();

        if (contactInfo == null)
        {
            contactInfo = new ContactInformation
            {
                Phone = dto.Phone,
                Number = dto.Number,
                Email = dto.Email,
                Address = dto.Address,
                PostCode = dto.PostCode,
                Location = dto.Location,
            };

            await _contactInformationRepository.AddAsync(contactInfo);
        }
        else
        {
            contactInfo.Phone = dto.Phone;
            contactInfo.Number = dto.Number;
            contactInfo.Email = dto.Email;
            contactInfo.Address = dto.Address;
            contactInfo.PostCode = dto.PostCode;
            contactInfo.Location = dto.Location;
        }

        await _generalServices.SaveAsync();
    }
}