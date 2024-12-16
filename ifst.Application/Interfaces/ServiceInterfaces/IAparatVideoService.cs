using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IAparatVideoService
{
    Task<AparatVideoDto> CreateAparatVideoAsync(CreateAparatVideoDto aparatVideo);
    
    Task<AparatVideoDto> GetAparatVideoAsync(int id);
    
    Task DeleteAparatVideoAsync(int id);
}