using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.Data.Repository;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly IContactUsRepository _repository;
        private readonly GeneralServices _generalServices;


        public ContactUsController(FileService fileService, GeneralServices generalServices,
            IContactUsRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
            _generalServices = generalServices;
        }

        [HttpPost("SubmitContactUs")]
        public async Task<IActionResult> SubmitContactUs([FromForm] string FullName, [FromForm] string Email,
            [FromForm] string Subject, [FromForm] string Body)
        {
            var contactObj = new ContactUs
            {
                FullName = FullName,
                Email = Email,
                Subject = Subject,
                Body = Body
            };

            await _repository.AddAsync(contactObj);
            await _generalServices.SaveAsync();

            var contactDtoObj = new ContactUsDto
            {
                Id = contactObj.Id,
                FullName = contactObj.FullName,
                Email = contactObj.Email,
                Body = contactObj.Body,
                Date = contactObj.Date,
            };

            return Ok(contactDtoObj);
        }

        [HttpGet("ListContactUs")]
        public async Task<IActionResult> ListContactUs(int page =1,int pageSize = 10)
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
    }
}