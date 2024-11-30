using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IPioneersService
{
    Task<PioneersDto> AddPioneerAsync(AddPioneersDto pioneers);
    Task<PioneersDto> GetPioneerAsync(GetPioneersDto pioneers);

    Task<PaginatedResult<PioneersDto>> GetAllPioneersAsync(GetAllPioneersDto getPioneersDto);
    Task RemovePioneerAsync(GetPioneersDto pioneers);
    
    Task<PioneersDto> UpdateNewsletterAsync(int id, UpdatePioneerDto newsletterDto);


}