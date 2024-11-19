using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PioneersController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly IPioneersRepository _repository;
        private readonly GeneralServices _generalServices;

        public PioneersController(FileService fileService, GeneralServices generalServices,
            IPioneersRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
            _generalServices = generalServices;
        }

        [HttpPost("AddPioneer")]
        public async Task<IActionResult> AddPioneer([FromForm] string name, [FromForm] string cityOfBirth,
            IFormFile file, [FromForm] string Projects_Description)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Pioneer's Name is required.");
            if (file == null || file.Length == 0)
                return BadRequest("Pioneer's Image File is required.");

            var path = await _fileService.SaveFileAsync(file, "Pioneer");

            var pioneer = new Pioneers
            {
                Name = name,
                CityOfBirth = cityOfBirth,
                ImagePath = path,
                ProjectsDescription = Projects_Description
            };
            await _repository.AddAsync(pioneer);
            await _generalServices.SaveAsync();

            var pioneerDto = new PioneersDto
            {
                Id = pioneer.Id,
                Name = pioneer.Name,
                CityOfBirth = pioneer.CityOfBirth,
                ImagePath = pioneer.ImagePath,
                Projects_Description = pioneer.ProjectsDescription
            };

            return Ok(pioneerDto);
        }

        [HttpGet("GetAllPioneers")]
        public async Task<IActionResult> GetAllPioneers(int page = 1, int pageSize = 10)
        {
            try
            {
                if (page <= 0 || pageSize <= 0)
                {
                    return BadRequest("Page and page size must be greater than zero.");
                }

                var totalPioneers = await _repository.GetAllAsync();
                var totalCount = totalPioneers.Count();

                var paginatedPioneers = totalPioneers
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                if (!paginatedPioneers.Any())
                {
                    return NotFound("No pioneers found for the given page.");
                }

                return Ok(new
                {
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize,
                    Data = paginatedPioneers
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        
        [HttpGet("GetPioneer")]
        public async Task<IActionResult> GetPioneer(int id)
        {
            var pioneer = await _repository.GetByIdAsync(id);
            if (pioneer == null)
                return NotFound("Pioneer not found.");
            return Ok(pioneer);
        }
    }
}