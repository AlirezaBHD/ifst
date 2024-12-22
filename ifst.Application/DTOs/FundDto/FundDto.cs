namespace ifst.API.ifst.Application.DTOs.FundDto;

public class FundDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GatheredAmount { get; set; }
    public ICollection<ProjectListDto> Projects { get; set; }
}