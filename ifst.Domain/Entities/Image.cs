﻿using System.ComponentModel;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("تصویر")]
public class Image
{
    public int Id { get; set; }
    public string Path  { get; set; }
    public string Description  { get; set; }
    
    public int? AlbumId  { get; set; }
    public Album? Album { get; set; }
}
