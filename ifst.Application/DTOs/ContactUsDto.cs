namespace ifst.API.ifst.Application.DTOs;

public class ContactUsDto
{
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
}