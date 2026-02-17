using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;

namespace MediaTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly UserListService _userListService;

    public TestController(UserListService userListService)
    {
        _userListService = userListService;
    }

    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Injection OK");
    }
}
