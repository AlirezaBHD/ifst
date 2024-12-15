using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneralController : ControllerBase
{
    #region Injections
    
    private readonly IPublicImageService _publicImageService;
    public GeneralController(IPublicImageService publicImageService)
    {
        _publicImageService = publicImageService;
    }
    
    #endregion
    
    #region Get Image

    [HttpGet("GetImage/{Id}")]
    public async Task<IActionResult> GetImage([FromRoute] GetObjectByIdDto imageId)
    {
        var image = await _publicImageService.GetPublicImage(imageId.Id);
        return Ok(image);
    }

    #endregion
    
    #region Get Image Detail

    [HttpGet("GetImage/{Id}/Detail")]
    public async Task<IActionResult> GetImageDetail([FromRoute] GetObjectByIdDto imageId)
    {
        var image = await _publicImageService.GetPublicImageDetail(imageId.Id);
        return Ok(image);
    }

    #endregion
    
    #region Post Image

    [HttpPost("PostImage")]
    public async Task<IActionResult> PostImage([FromForm] CreatePublicImageDto image){
        var imageDto = await _publicImageService.AddPublicImage(image);
        return CreatedAtAction(nameof(GetImageDetail), new { Id = imageDto.Id }, imageDto);
    }

    #endregion
    
    #region Update Image
    
    [HttpPut("UpdateImage/{Id}")]
    public async Task<IActionResult> UpdateImage([FromRoute] GetImageDto imageId, [FromForm] UpdatePublicImageDto image){
        await _publicImageService.UpdateImage(imageId.Id, image);
        return Ok($".تصویر شماره {imageId.Id} موفقیت ویرایش داده شد");
    }

    #endregion
    
    #region Delete Image
    [HttpDelete("DeleteImage/{Id}")]
    public async Task<IActionResult> DeleteImage([FromRoute] GetImageDto imageId){
        await _publicImageService.DeleteImage(imageId.Id);
        return Ok($".تصویر شماره {imageId.Id} موفقیت حذف شد");
    }
    #endregion
    
}