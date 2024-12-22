using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.FundDto;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FundController: ControllerBase
{
    #region Injection

    private readonly IFundService _fundService;

    public FundController(IFundService fundService)
    {
        _fundService = fundService;
    }

    #endregion
    
    #region Get By Id
    
    [HttpGet("Fund/{Id}")]
    public async Task<IActionResult> FundById([FromRoute] GetObjectByIdDto updateProjectId)
    {
        var fundObj = await _fundService.FundDetailById(updateProjectId.Id);
        return Ok(fundObj);
    }
    
    #endregion

    #region Get All Funds

    [HttpGet("Fund/List")]
    public async Task<IActionResult> FundList()
    {
        var fundList = await _fundService.ListFunds();
        return Ok(fundList);
    }

    #endregion

    #region Add Fund

    [HttpPost("Fund/Create")]
    public async Task<IActionResult> CreateFund(CreateFundDto fundDto)
    {
        var fund = await _fundService.CreateFunds(fundDto);
        return CreatedAtAction(nameof(FundById), new { Id = fund.Id }, fund);
    }

    #endregion

    #region Update Fund Amount

    [HttpPut("Fund/Update/{Id}")]
    public async Task<IActionResult> UpdateFund([FromRoute] GetObjectByIdDto id, UpdateFundDto fundDto)
    {
        await _fundService.UpdateFund(id.Id, fundDto);
        return Ok($".مبلغ با موفقیت به صندوق شماه {id.Id} اضافه شد");
    }

    #endregion

    #region Delete Found

    [HttpDelete("Fund/Delete/{Id}")]
    public async Task<IActionResult> DeleteFund([FromRoute] GetObjectByIdDto id)
    {
        await _fundService.DeleteFund(id.Id);
        return Ok($".صندق شماره {id.Id} با موفقیت حذف شد");
    }

    #endregion
}