using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;
[DisplayName("اطلاعات تماس")]
public class ContactInformation
{
    public int Id { get; set; }
    public string? Phone { get; set; }
    public string? Number { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public int? PostCode { get; set; }
    public string? Location { get; set; }
}
