using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.NewsDto;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class NewsService : INewsService
{
    #region Injections
    
    private readonly IMapper _mapper;
    private readonly IGeneralServices<News> _generalServices;
    private readonly INewsRepository _newsRepository;
    private readonly FileService _fileService;


    public NewsService(INewsRepository newsRepository, IGeneralServices<News> generalServices, IMapper mapper,
        FileService fileService)
    {
        _newsRepository = newsRepository;
        _generalServices = generalServices;
        _mapper = mapper;
        _fileService = fileService;
    }

    #endregion
    
    
    #region Add News

    public async Task<NewsDto> AddNews(CreateNewsDto newsDto)
    {
        var newsObj = _mapper.Map<News>(newsDto);
        var imagePath = await _fileService.SaveFileAsync(newsDto.Image, "News");
        newsObj.ImagePath = imagePath;
        await _newsRepository.AddAsync(newsObj);
        await _newsRepository.SaveAsync();
        var newsDtoObj = _mapper.Map<NewsDto>(newsObj);
        return newsDtoObj;
    }

    #endregion


    #region Get News

    public async Task<NewsDetailDto> GetNews(int id)
    {
        var newsObj = await _newsRepository.GetByIdAsyncLimited<NewsDetailDto>(id);
        return newsObj;
    }

    #endregion


    #region Delete News

    public async Task DeleteNews(int id)
    {
        var news = await _newsRepository.GetByIdAsync(id);
        _newsRepository.Remove(news);
        await _newsRepository.SaveAsync();
    }
    
    #endregion
    
    
    public async Task UpdateNews(int id, UpdateNewsDto newsDto)
    {
        var news = await _newsRepository.GetByIdAsync(id);
        var files = new Dictionary<string, IFormFile>
        {
            { nameof(news.ImagePath), newsDto.Image }
        };
        await _generalServices.UpdateEntityAsync(news, newsDto, files);
        // await _newsRepository.SaveAsync();
    }

    public async Task<PaginatedResult<ListedNewsDto>> GetNewsListPaginatedAsync(FilterAndSortPaginatedOptions options)
    {
        var resultObjects = await _newsRepository.GetFilteredAndSortedPaginated<ListedNewsDto>(options);
        return resultObjects;
    }
    
}