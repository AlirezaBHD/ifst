namespace ifst.API.ifst.Application.DTOs.GeneralDto.Image;

public class CreatePublicImageDto
{
    public IFormFile ImageFile { get; set; }
    public string? Description { get; set; }
}