using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces;

public interface IAboutUsRepository : IRepository<AboutUs>
{
    Task<AboutUs> AboutUsObject();
}