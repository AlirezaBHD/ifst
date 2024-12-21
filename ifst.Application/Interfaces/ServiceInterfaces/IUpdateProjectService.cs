using ifst.API.ifst.Application.DTOs.UpdateProjectDto;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IUpdateProjectService
{
    Task<UpdateProjectDetailDto> UpdateProjectDetail(int id);
}