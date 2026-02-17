using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Entities;

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
    public IActionResult CreateMedia(string title, MediaCategory category)
    {
        Media? media = _service.CreateMedia(title, category);
        return Ok(media);
    }

    [HttpGet]
    public IActionResult GetAllMedia()
    {
        IEnumerable<Media> media = _service.GetAll();
        return Ok(media);
    }
}
