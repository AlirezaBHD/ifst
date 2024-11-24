namespace ifst.API.ifst.Application.DTOs;



public class AddImageDto
{
    public IFormFile File { get; set; }
    public string Description { get; set; }
}

public class GetImageDto
{
    public int Id { get; set; }
}
public class ImageDto
{
    public int Id { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }
    public int AlbumId { get; set; }
    
}

