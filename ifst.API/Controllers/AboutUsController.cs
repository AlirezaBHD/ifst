using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutUsController : ControllerBase
{
    #region Injection

    private readonly IAboutUsService _aboutUsService;

    public AboutUsController(IAboutUsService aboutUsService)
    {
        _aboutUsService = aboutUsService;
    }

    #endregion

    [HttpGet("AboutUs")]
    public async Task<IActionResult> GetAboutUsAsync()
    {
        var result = await _aboutUsService.GetAboutUsAsync();
        return Ok(result);
    }
}