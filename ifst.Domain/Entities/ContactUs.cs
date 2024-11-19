using System.ComponentModel.DataAnnotations;

namespace ifst.API.ifst.Domain.Entities;

public class ContactUs
{
    public ContactUs()
    {
        Date = DateTime.Now;
    }
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }
    public string Email { get; set; }
    public string? Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; private set; }
}
