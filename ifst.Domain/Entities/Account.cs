using System.ComponentModel.DataAnnotations;

namespace ifst.API.ifst.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NationalCode { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}