using System.ComponentModel;

namespace ifst.API.ifst.Application.DTOs;

public class ContactUsDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
}

public class AllContactUsDto
{
    [DefaultValue(1)] public int Page { get; set; }
    [DefaultValue(10)] public int PageSize { get; set; }
}

public class CreateContactUs
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}