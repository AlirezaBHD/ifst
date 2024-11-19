
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.DTOs;

public class AlbumDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ImageDto> Images { get; set; }
}

public class ImageDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }
}

public class ImageUploadDto
{
    public IFormFile File { get; set; }
    public string Description { get; set; }
}