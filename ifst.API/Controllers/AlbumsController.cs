using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.Data;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ifst.API.ifst.Application.Services;


namespace ifst.API.ifst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        
        private readonly FileService _fileService;
        private readonly IAlbumRepository _albumGeneralRepository;
        private readonly IRepository<Image> _imageGeneralRepository;
        private readonly GeneralServices _generalServices;

        public AlbumsController(FileService fileService,
            IAlbumRepository albumRepository, GeneralServices generalServices, IRepository<Image> imageRepository)
        {
            _fileService = fileService;
            _albumGeneralRepository = albumRepository;
            _imageGeneralRepository = imageRepository;
            _generalServices = generalServices;
        }

        [HttpPost("CreateAlbum")]
        public async Task<IActionResult> CreateAlbum([FromForm] string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest("Album title is required.");

            var album = new Album
            {
                Title = title,
                Images = new List<Image>()
            };

            await _albumGeneralRepository.AddAsync(album);
            await _generalServices.SaveAsync();


            var albumDto = new AlbumDto
            {
                Id = album.Id,
                Title = album.Title,
            };

            return Ok(albumDto);
        }

        [HttpPost("AddImage")]
        public async Task<IActionResult> AddImage(IFormFile file, [FromForm] string description, [FromForm] int albumId)
        {
            if (string.IsNullOrEmpty(description))
                return BadRequest("Description is required.");
            if (file == null || file.Length == 0)
                return BadRequest("File is required.");
            var album = await _albumGeneralRepository.GetByIdAsync(albumId);


            if (album == null)
            {
                return NotFound("Album not found.");
            }

            var path = await _fileService.SaveFileAsync(file , "Albums");

            var image = new Image
            {
                Path = path,
                Description = description,
                AlbumId = albumId
            };

            await _imageGeneralRepository.AddAsync(image);
            album.Images.Add(image);
            await _generalServices.SaveAsync();

            var imageDto = new ImageDto
            {
                Id = image.Id,
                Path = image.Path,
                Description = image.Description
            };

            return Ok(imageDto);
        }

        [HttpDelete("DeleteAlbum/{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _albumGeneralRepository.GetByIdAsync(id);
            if (album == null)
                return NotFound("Album not found.");

            _albumGeneralRepository.Remove(album);
            await _generalServices.SaveAsync();

            return Ok("Album deleted.");
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _imageGeneralRepository.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound("Image not found.");
            }
            return Ok(image);
        }
        
        [HttpGet("GetAlbum")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var album = await _albumGeneralRepository.GetByIdAsync(id);
            // var album = _albumGeneralRepository.GetAlbumByIdAsync

            if (album == null)
            {
                return NotFound("Image not found.");
            }
            return Ok(album);
        }
    }
}