﻿namespace ifst.API.ifst.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string Path  { get; set; }
    public string Description  { get; set; }
    
    public int? AlbumId  { get; set; }
    public Album? Album { get; set; }
}

public class Album
{
    public int Id { get; set; }
    public string Title  { get; set; }
    public ICollection<Image> Images  { get; set; }
}