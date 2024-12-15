using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces;

public interface IInstituteRepository: IRepository<Institute>
{
    Task<IEnumerable<InstituteDto>> GetAllInstitutesAndProjects();
}