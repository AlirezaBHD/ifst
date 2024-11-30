namespace ifst.API.ifst.Application.Extensions;

public class FilterAndSortOptions
{
    public IDictionary<string, string?> Filters { get; set; } = new Dictionary<string, string?>();
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = false;
}
