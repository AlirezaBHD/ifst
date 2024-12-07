using ifst.API.ifst.Application.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IInstituteService
{
    Task<InstituteDto> AddInstitute(CreateInstituteDto createAlbumDto);
    Task<InstituteDto> GetInstitute(int id);
    Task PatchInstitute(int id,JsonPatchDocument<PatchInstitutesDto> patchDoc);
    Task InstituteStatus(GetObjectByIdDto instituteDto, PatchInstitutesStatusDto institutesStatusDto);
    // Task<InstituteDto> UpdateInstitute(CreateInstituteDto createAlbumDto);
    Task<IEnumerable<MainListedInstitutesDto>> GetAllInstitutes();
    Task<IEnumerable<ListedInstitutesDto>> GetAllConfirmedInstitutes();

}