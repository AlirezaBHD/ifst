using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;
[DisplayName("خبرنامه")]
public class Newsletter
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string FilePath { get; set; }
}