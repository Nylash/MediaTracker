using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;
using MediaTracker.Domain.Enums;

namespace MediaTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly MediaService _service;

    public MediaController(MediaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(string title, MediaCategory category)
    {
        var media = _service.CreateMedia(title, category);
        return Ok(media);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var media = _service.GetAll();
        return Ok(media);
    }
}
