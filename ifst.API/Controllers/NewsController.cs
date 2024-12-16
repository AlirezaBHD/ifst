using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.NewsDto;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    #region Injection

    private readonly INewsService _newsService;
    
    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    #endregion
    
    #region Get News

    [HttpGet("GetNews/{Id}")]
    public async Task<IActionResult> GetNews([FromRoute] GetObjectByIdDto newsDto)
    {
        var newsDtoObj = await _newsService.GetNews(newsDto.Id);
        return Ok(newsDtoObj);
    }

    #endregion

    #region Add News
    
    [HttpPost("AddNews")]
    public async Task<IActionResult> AddNews([FromForm] CreateNewsDto newsDto)
    {
        var newsObjDto = await _newsService.AddNews(newsDto);
        return CreatedAtAction(nameof(GetNews), new { Id = newsObjDto.Id }, newsObjDto);
    }
    
    #endregion

    #region Delete News

    [HttpDelete("DeleteNews/{Id}")]
    public async Task<IActionResult> DeleteNews([FromRoute] GetObjectByIdDto newsDto)
    {
        var id = newsDto.Id;
        await _newsService.DeleteNews(id);
        return Ok($".خبر شماره {id} با موفقیت حذف شد");
    }

    #endregion

    #region Update News

    [HttpPut("UpdateNews/{Id}")]
    public async Task<IActionResult> UpdateNews([FromRoute] GetObjectByIdDto newsDtoId, [FromForm] UpdateNewsDto newsDto)
    {
        var id = newsDtoId.Id;
        await _newsService.UpdateNews(id, newsDto);
        return Ok($".خبر شماره {id} با موفقیت ویرایش داده شد");
    }

    #endregion

    #region Get News List

    [HttpGet("GetAllNews")]
    public async Task<IActionResult> GetAllNews([FromQuery] FilterAndSortPaginatedOptions options)
    {
        var result = await _newsService.GetNewsListPaginatedAsync(options);
        return Ok(result);
    }

    #endregion
}