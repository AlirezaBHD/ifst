﻿using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AparatVideoController : ControllerBase
{
    #region Injection

    private readonly IAparatVideoService _aparatVideoService;

    public AparatVideoController(IAparatVideoService aparatVideoService)
    {
        _aparatVideoService = aparatVideoService;
    }

    #endregion
    
    #region Get AparatVideo
    
    [HttpGet("GetAparatVideo/{Id}")]
    public async Task<IActionResult> GetAparatVideo([FromRoute] GetObjectByIdDto aparatVideoId)
    {
        var id = aparatVideoId.Id;
        var aparatVideoDto = await _aparatVideoService.GetAparatVideoAsync(id);
        return Ok(aparatVideoDto);
    }
    
    #endregion
    
    #region Post AparatVideo

    [HttpPost("PostAparatVideo")]
    public async Task<IActionResult> PostAparatVideo([FromBody] CreateAparatVideoDto aparatVideo)
    {
        var aparatVideoDto = await _aparatVideoService.CreateAparatVideoAsync(aparatVideo);
        return CreatedAtAction(nameof(GetAparatVideo), new { Id = aparatVideoDto.Id }, aparatVideoDto);
    }

    #endregion
}