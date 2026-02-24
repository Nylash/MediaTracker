using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(CreateUserRequest request)
    {
        var user = _service.Create(request.Username, request.Email);

        return CreatedAtAction(
            nameof(GetById),
            new { id = user.Id },
            user
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var user = _service.Get(id);
        return Ok(user);
    }
}