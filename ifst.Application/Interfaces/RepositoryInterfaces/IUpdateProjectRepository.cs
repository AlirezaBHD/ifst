using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces;

public interface IUpdateProjectRepository: IRepository<UpdateProject>
{
    Task<UpdateProject> UpdateProjectObject(int id);
}