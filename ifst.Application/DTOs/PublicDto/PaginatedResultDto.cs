using System.ComponentModel;

namespace ifst.API.ifst.Application.DTOs;

public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
    [DefaultValue(1)] public int PageNumber { get; set; }
    [DefaultValue(10)] public int PageSize { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}