using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface INewsletterService
{
    Task<NewsletterDto> AddNewsletterAsync(AddNewsletterDto newsletterDto);

    Task<PaginatedResult<Newsletter>> GetNewslettersAsync(FilterAndSortPaginatedOptions options);

    Task<NewsletterDto> GetNewsletter(GetObjectByIdDto newsletter);

    Task<Newsletter> UpdateNewsletterAsync(int id, PatchNewsletterDto newsletterDto);

    Task DeleteNewsletterAsync(GetObjectByIdDto newsletter);
}