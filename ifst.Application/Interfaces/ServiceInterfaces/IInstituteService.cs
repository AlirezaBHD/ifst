using ifst.API.ifst.Application.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IInstituteService
{
    Task<InstituteDto> AddInstitute(CreateInstituteDto createAlbumDto);
    Task<InstituteDto> GetInstitute(int id);
    Task<string> Deactivate(int id);
    Task<string> Activate(int id);
    Task PatchInstitute(int id,JsonPatchDocument<PatchInstitutesDto> patchDoc);
    // Task<InstituteDto> UpdateInstitute(CreateInstituteDto createAlbumDto);
    // Task<InstituteDto> DeleteInstitute(CreateInstituteDto createAlbumDto);
    Task<IEnumerable<MainListedInstitutesDto>> GetAllInstitutes();
    Task<IEnumerable<ListedInstitutesDto>> GetAllConfirmedInstitutes();

}