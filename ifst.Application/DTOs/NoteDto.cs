namespace ifst.API.ifst.Application.DTOs;

public class NoteDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ImagePath { get; set; }
    
    public string Summery { get; set; }
    
    public string Body { get; set; }
    
    public DateTime Date { get; set; }
}

public class AddNoteDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }

    public string Summery { get; set; }

    public string Body { get; set; }
}

public class listedNoteDto
{
    public string Title { get; set; }
    
    public string ImagePath { get; set; }
    
    public string Summery { get; set; }
}


public class NoteCompleteDto
{
    public string Title { get; set; }
    
    public string ImagePath { get; set; }
    
    public string Body { get; set; }
}