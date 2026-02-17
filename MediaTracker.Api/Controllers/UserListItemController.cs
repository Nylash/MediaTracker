using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserListItemController : ControllerBase
{
    private readonly UserListItemService _service;

    public UserListItemController(UserListItemService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddMediaEntry(Guid listId, Guid mediaId)
    {
        _service.AddMediaToList(listId, mediaId);
        return Ok();
    }

    [HttpGet("{listId}")]
    public IActionResult GetAllMediaEntries(Guid listId)
    {
        IEnumerable<UserListItem> items = _service.GetListItems(listId);
        return Ok(items);
    }

    [HttpDelete]
    public IActionResult RemoveEntry(Guid listId, Guid mediaId)
    {
        _service.RemoveMediaFromList(listId, mediaId);
        return Ok();
    }
}
