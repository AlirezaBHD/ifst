
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.DTOs;

public class CreateAlbumDto
{
    public string Title { get; set; }
    public string Category { get; set; }

}

public class GetAlbumDto
{
    public int Id { get; set; }
}


public class AlbumDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public List<ImageDto> Images { get; set; }
}

public class EditAlbumDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Category { get; set; }

}

