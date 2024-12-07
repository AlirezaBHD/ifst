namespace ifst.API.ifst.Application.DTOs;

public class PatchOperationDto
{
    public string Op { get; set; }
    public string Path { get; set; }
    public object Value { get; set; }
}