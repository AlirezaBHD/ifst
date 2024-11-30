namespace ifst.API.ifst.Application.Extensions;

public class FilterAndSortPaginatedOptions
{
    public IDictionary<string, string?> Filters { get; set; } = new Dictionary<string, string?>();
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}