using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IAboutUsService
{
    Task<AboutUsDto> GetAboutUsAsync();
    
    Task PutAboutUsAsync(CreateAboutUsDto aboutUsDto);
}