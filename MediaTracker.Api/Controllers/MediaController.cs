using MediaTracker.Api.Dtos;
using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CreateMedia([FromBody] CreateMediaRequest request)
    {
        var media = _service.CreateMedia(
            request.Title,
            (MediaCategory)request.Category
        );

        return Ok(media);
    }

    [HttpGet]
    public IActionResult GetAllMedia()
    {
        IEnumerable<Media> media = _service.GetAll();
        return Ok(media);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMediaById(Guid id)
    {
        var media = _service.Get(id);

        if (media == null)
            return NotFound();

        return Ok(media);
    }
}
