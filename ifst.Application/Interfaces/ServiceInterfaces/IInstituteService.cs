using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IInstituteService
{
    Task<InstituteDto> AddInstitute(CreateInstituteDto createAlbumDto);
    // Task<InstituteDto> GetInstitute(CreateInstituteDto createAlbumDto);
    // Task<InstituteDto> UpdateInstitute(CreateInstituteDto createAlbumDto);
    // Task<InstituteDto> DeleteInstitute(CreateInstituteDto createAlbumDto);
    // Task<InstituteDto> GetAllInstitutes(CreateInstituteDto createAlbumDto);

}