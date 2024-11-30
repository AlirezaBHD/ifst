using System.Drawing;
using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
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
        private readonly IPioneersService _pioneersService;

        public PioneersController(IPioneersService pioneersService)
        {
            _pioneersService = pioneersService;
        }

        [HttpPost("AddPioneer")]
        public async Task<IActionResult> AddPioneer([FromForm] AddPioneersDto pioneerDto)
        {
            var pioneerDtoObj = await _pioneersService.AddPioneerAsync(pioneerDto);

            return Ok(pioneerDtoObj);
        }

        [HttpGet("GetPioneer")]
        public async Task<IActionResult> GetPioneer([FromQuery] GetPioneersDto getPioneerDto)
        {
            var pioneerDtoObj = await _pioneersService.GetPioneerAsync(getPioneerDto);

            return Ok(pioneerDtoObj);
        }


        [HttpGet("GetAllPioneers")]
        public async Task<IActionResult> GetAllPioneers([FromQuery] GetAllPioneersDto getPioneersDto)
        {
            var dtoResult = await _pioneersService.GetAllPioneersAsync(getPioneersDto);
            return Ok(dtoResult);
        }

        [HttpDelete("RemovePioneer/{getPioneerDto.Id}")]
        public async Task<IActionResult> RemovePioneer([FromRoute] GetPioneersDto getPioneerDto)
        {
            await _pioneersService.RemovePioneerAsync(getPioneerDto);
            return Ok("Pioneer Has Been Deleted");
        }

        [HttpPut("UpdatePioneer/{getPioneerDto.Id}")]
        public async Task<IActionResult> UpdatePioneer([FromRoute] GetPioneersDto getPioneerDto , [FromForm] UpdatePioneerDto pioneerDto)
        {
            
            var result = await _pioneersService.UpdateNewsletterAsync(getPioneerDto.Id, pioneerDto);
            
            return Ok(result);
        }
    }
}