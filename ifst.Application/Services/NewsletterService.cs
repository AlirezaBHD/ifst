using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Services;

public class NewsletterService : INewsletterService
{
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;
    private readonly INewsletterRepository _newsletterRepository;
    private readonly FileService _fileService;

    public NewsletterService(IMapper mapper, IGeneralServices generalServices,
        INewsletterRepository newsletterRepository, FileService fileService)
    {
        _newsletterRepository = newsletterRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<NewsletterDto> GetNewsletter(GetObjectByIdDto newsletter)
    {
        var newsletterObj = await _newsletterRepository.GetByIdAsync(newsletter.Id);
        var newsletterDtoObj = _mapper.Map<NewsletterDto>(newsletterObj);
        return newsletterDtoObj;
    }

    public async Task<NewsletterDto> AddNewsletterAsync(AddNewsletterDto newsletterDto)
    {
        var imagePath = await _fileService.SaveFileAsync(newsletterDto.ImageFile, "Newsletter");
        var filePath = await _fileService.SaveFileAsync(newsletterDto.File, "Newsletter");
        var newsletter = _mapper.Map<Newsletter>(newsletterDto);
        newsletter.ImagePath = imagePath;
        newsletter.FilePath = filePath;

        await _newsletterRepository.AddAsync(newsletter);
        await _generalServices.SaveAsync();
        var dto = _mapper.Map<NewsletterDto>(newsletter);
        return dto;
    }

    public async Task<PaginatedResult<Newsletter>> GetNewslettersAsync(FilterAndSortPaginatedOptions options)
    {
        var paginatedResult = await _newsletterRepository.GetFilteredAndSortedPaginated(options);
        // var mappedItems =_mapper.Map<IEnumerable<Newsletter>, IEnumerable<NewsletterDto>>(paginatedResult.Items);
        //
        //
        // var result = new PaginatedResult<NewsletterDto>
        // {
        //     Items = mappedItems,
        //     TotalCount = paginatedResult.TotalCount,
        //     PageNumber = paginatedResult.PageNumber,
        //     PageSize = paginatedResult.PageSize,
        // };
        //
        //     
        // return result;
        return paginatedResult;
    }


    public async Task<Newsletter> UpdateNewsletterAsync(int id, PatchNewsletterDto newsletterDto)

    {
        var obj = await _newsletterRepository.GetByIdAsync(id);


        var updatedNewsletter = _mapper.Map(newsletterDto, obj);
        if (newsletterDto.ImageFile != null)
        {
            var imagePath = await _fileService.SaveFileAsync(newsletterDto.ImageFile, "Newsletter");
            updatedNewsletter.ImagePath = imagePath;
        }

        if (newsletterDto.File != null)
        {
            var filePath = await _fileService.SaveFileAsync(newsletterDto.File, "Newsletter");
            updatedNewsletter.FilePath = filePath;
        }

        _newsletterRepository.Update(updatedNewsletter);
        await _generalServices.SaveAsync();
        return updatedNewsletter;
    }

    public async Task DeleteNewsletterAsync(GetObjectByIdDto newsletter)
    {
        var newsletterObj = await _newsletterRepository.GetByIdAsync(newsletter.Id);
        _newsletterRepository.Remove(newsletterObj);
        await _generalServices.SaveAsync();
    }
}