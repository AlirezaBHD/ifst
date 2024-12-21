using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("صندوق")]
public class Fund
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    public int? GatheredAmount { get; set; } = 0;
    public ICollection<Project> Projects { get; set; } = new List<Project>();

}