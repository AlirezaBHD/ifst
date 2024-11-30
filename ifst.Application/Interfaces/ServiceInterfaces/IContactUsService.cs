using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IContactUsService
{
    Task AddContactUsAsync(ContactUsDto contactUsDto);
    
    Task<ContactUs> GetContactUsByIdAsync(GetObjectByIdDto contactUsDto);
    
    Task<PaginatedResult<ContactUs>> FilteredPaginatedContactUsList(FilterAndSortPaginatedOptions options);
}