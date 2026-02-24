using MediaTracker.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MediaEntryController : ControllerBase
{
    private readonly MediaEntryService _service;

    public MediaEntryController(MediaEntryService service)
    {
        _service = service;
    }

    [HttpGet("by-media/{mediaId:guid}")]
    public IActionResult GetByMedia(Guid mediaId, Guid userId)
    {
        var entry = _service.GetByMedia(userId, mediaId);

        return Ok(entry);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateMediaEntryRequest request)
    {
        var entry = _service.Create(
            request.UserId,
            request.MediaId,
            request.Status
        );

        return Ok(entry);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] UpdateMediaEntryRequest request)
    {
        var updated = _service.UpdateStatus(id, request.Status);
        return Ok(updated);
    }

    [HttpGet("{id:guid}/deletion-info")]
    public IActionResult GetDeletionInfo(Guid id)
    {
        var info = _service.GetDeletionInfo(id);
        return Ok(info);
    }
}