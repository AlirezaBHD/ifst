using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;
[DisplayName("حساب کاربری")]
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