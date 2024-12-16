using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AparatVideoController : ControllerBase
{
    #region Injection

    private readonly IAparatVideoService _aparatVideoService;

    public AparatVideoController(IAparatVideoService aparatVideoService)
    {
        _aparatVideoService = aparatVideoService;
    }
    #endregion
}