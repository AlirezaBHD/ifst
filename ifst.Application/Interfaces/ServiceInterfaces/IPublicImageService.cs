using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IPublicImageService
{
    Task<PublicImage> AddPublicImage(CreatePublicImageDto publicImage);

    Task<GetPublicImageDto> GetPublicImage(int id);

    Task<GetPublicImageDetailDto> GetPublicImageDetail(int id);

    Task DeleteImage(int id);
    
    Task UpdateImage(int id, UpdatePublicImageDto image);
}