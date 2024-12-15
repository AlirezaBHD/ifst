using ifst.API.ifst.Application.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IInstituteService
{
    Task<InstituteDto> AddInstitute(CreateInstituteDto createAlbumDto);
    Task<InstituteDto> GetInstitute(int id);
    Task PatchInstitute(int id,JsonPatchDocument<PatchInstitutesDto> patchDoc);
    Task InstituteStatus(GetObjectByIdDto instituteDto, PatchInstitutesStatusDto institutesStatusDto);
    Task UpdateInstitute(int id, CreateInstituteDto instituteDto);
    Task<PaginatedResult<MainListedInstitutesDto>> GetAllInstitutes(int pageNumber,
        int pageSize);
    Task<IEnumerable<ListedInstitutesDto>> GetAllConfirmedInstitutes();

    Task<IEnumerable<InstituteDto>> GetAllInstitutesAndProjects();

}