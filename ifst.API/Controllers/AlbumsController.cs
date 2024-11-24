using System.Diagnostics;
using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;
using ifst.API.ifst.Application.Services;


namespace ifst.API.ifst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpPost("CreateAlbum")]
        public async Task<IActionResult> CreateAlbum([FromForm] CreateAlbumDto createAlbumDto)
        {
                var albumDtoObj = await _albumService.CreateAlbumAsync(createAlbumDto);

                // return CreatedAtAction(albumDtoObj.Title,new { id = albumDtoObj.Id },albumDtoObj);
                return Ok(albumDtoObj);
        }

        [HttpGet("GetAlbum")]
        public async Task<IActionResult> GetAlbum([FromQuery] GetAlbumDto albumDto)
        {
                var albumDtoObj = await _albumService.GetAlbumByIdAsync(albumDto.Id);
                return Ok(albumDtoObj);
        }


        [HttpDelete("DeleteAlbum/{deleteAlbumDto.Id}")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] GetAlbumDto deleteAlbumDto)
        {
            await _albumService.DeleteAlbumByIdAsync(deleteAlbumDto.Id);

            return Ok(".آلبوم و عکس های موجود در آلبوم با موفقت حذف شد");
        }
    }
}