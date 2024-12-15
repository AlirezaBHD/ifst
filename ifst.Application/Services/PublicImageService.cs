using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.Identity.Client;

namespace ifst.API.ifst.Application.Services;

public class PublicImageService : IPublicImageService
{
    #region Injection

    private readonly IMapper _mapper;
    private readonly FileService _fileService;
    private readonly IGeneralServices<PublicImage> _generalServices;
    private readonly IPublicImageRepository _publicImageRepository;

    public PublicImageService(IPublicImageRepository publicImageRepository, IMapper mapper,
        FileService fileService, IGeneralServices<PublicImage> generalServices)
    {
        _publicImageRepository = publicImageRepository;
        _mapper = mapper;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    #endregion

    #region Add Public Image

    public async Task<PublicImage> AddPublicImage(CreatePublicImageDto publicImage)
    {
        var publicImageEntity = _mapper.Map<PublicImage>(publicImage);
        var imagePath = await _fileService.SaveFileAsync(publicImage.ImageFile, "PublicImages");
        publicImageEntity.Path = imagePath;
        await _publicImageRepository.AddAsync(publicImageEntity);
        await _publicImageRepository.SaveAsync();
        return publicImageEntity;
    }

    #endregion

    #region Get PublicImage

    public async Task<GetPublicImageDto> GetPublicImage(int id)
    {
        var image = await _publicImageRepository.GetByIdAsyncLimited<GetPublicImageDto>(id);
        return image;
    }

    #endregion

    #region Get PublicImage Detail

    public async Task<GetPublicImageDetailDto> GetPublicImageDetail(int id)
    {
        var image = await _publicImageRepository.GetByIdAsyncLimited<GetPublicImageDetailDto>(id);
        return image;
    }

    #endregion

    #region Delete Image

    public async Task DeleteImage(int id)
    {
        var image = await _publicImageRepository.GetByIdAsync(id);
        _publicImageRepository.Remove(image);
        await _publicImageRepository.SaveAsync();
    }

    #endregion

    #region Update Image

    public async Task UpdateImage(int id, UpdatePublicImageDto image)
    {
        var imageEntity = await _publicImageRepository.GetByIdAsync(id);

        var files = new Dictionary<string, IFormFile>
        {
            { nameof(imageEntity.Path), image.ImageFile }
        };

        await _generalServices.UpdateEntityAsync(imageEntity, image, files);
    }

    #endregion
}