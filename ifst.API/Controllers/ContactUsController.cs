using FluentValidation;
using FluentValidation.Results;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
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
        private readonly IContactUsService _contactUsService;
        private readonly IContactUsRepository _repository;
        private readonly IGeneralServices _generalServices;


        public ContactUsController(IGeneralServices generalServices,
            IContactUsRepository repository, IContactUsService contactUsService)
        {
            _repository = repository;
            _generalServices = generalServices;
            _contactUsService = contactUsService;
        }


        [HttpGet("GetContactUs")]
        public async Task<IActionResult> GetContactUsAsync([FromQuery] GetObjectByIdDto getObjectDto)
        {
            var ContactUsObj = await _contactUsService.GetContactUsByIdAsync(getObjectDto);
            return Ok(ContactUsObj);
        }

        [HttpPost("SubmitContactUs")]

        public async Task<IActionResult> SubmitContactUs([FromBody] CreateContactUs contactUsDto)
        {
            await _contactUsService.AddContactUsAsync(contactUsDto);
            return Ok("پیام شما ارسال شد");
        }

        [HttpGet("ListContactUs")]
        public async Task<IActionResult> ListContactUs([FromQuery] FilterAndSortPaginatedOptions options)
        {

            var result = await _contactUsService.FilteredPaginatedContactUsList(options);

            return Ok(result);
        }
    }
}