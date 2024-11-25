using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IContactInformationService
{
    Task UpdateContactInformation(ContactInformationDto dto);

    Task<ContactInformationDto> GetContactInformation();
}