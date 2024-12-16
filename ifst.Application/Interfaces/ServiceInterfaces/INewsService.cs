using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.NewsDto;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface INewsService
{
    Task<NewsDto> AddNews(CreateNewsDto newsDto);

    Task<NewsDetailDto> GetNews(int id);

    Task DeleteNews(int id);

    Task UpdateNews(int id, UpdateNewsDto newsDto);
    Task<PaginatedResult<ListedNewsDto>> GetNewsListPaginatedAsync(FilterAndSortPaginatedOptions options);
}