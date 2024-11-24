using System.Drawing;
using AutoMapper;
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
        private readonly IMapper _mapper;

        private readonly FileService _fileService;
        private readonly IPioneersRepository _repository;
        private readonly GeneralServices _generalServices;

        public PioneersController(IMapper mapper, FileService fileService, GeneralServices generalServices,
            IPioneersRepository repository)
        {
            _mapper = mapper;

            _fileService = fileService;
            _repository = repository;
            _generalServices = generalServices;
        }

        [HttpPost("AddPioneer")]
        public async Task<IActionResult> AddPioneer([FromForm] AddPioneersDto pioneerDto)
        {
            var path = await _fileService.SaveFileAsync(pioneerDto.File, "Pioneer");

            var pioneer = _mapper.Map<Pioneers>(pioneerDto);
            pioneer.ImagePath = path;

            await _repository.AddAsync(pioneer);
            await _generalServices.SaveAsync();

            var pioneerDtoObj = _mapper.Map<PioneersDto>(pioneer);

            return Ok(pioneerDtoObj);
        }

        [HttpGet("GetPioneer")]
        public async Task<IActionResult> GetPioneer([FromQuery] GetPioneersDto getPioneerDto)
        {
            var pioneer = await _repository.GetByIdAsync(getPioneerDto.Id);
            var pioneerDtoObj = _mapper.Map<PioneersDto>(pioneer);

            return Ok(pioneerDtoObj);
        }


        [HttpGet("GetAllPioneers")]
        public async Task<IActionResult> GetAllPioneers([FromQuery] GetAllPioneersDto getPioneersDto)
        {
            var totalPioneers = await _repository.GetAllAsync();
            var totalCount = totalPioneers.Count();

            var paginatedPioneers = await _repository.GetAllPaginated(null, pageNumber: getPioneersDto.Page,
                pageSize: getPioneersDto.PageSize);
            
            var dtoResult = new PaginatedResult<PioneersDto>
            {
                
                Items = paginatedPioneers.Items.Select(p => _mapper.Map<PioneersDto>(p)).ToList(),
                TotalCount = paginatedPioneers.TotalCount,
                PageNumber = paginatedPioneers.PageNumber,
                PageSize = paginatedPioneers.PageSize
            };


            return Ok(dtoResult);
        }
    }
}