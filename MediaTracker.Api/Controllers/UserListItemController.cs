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
    public IActionResult AddMediaEntry(Guid listId, Guid mediaEntryId)
    {
        _service.AddMediaEntryToList(listId, mediaEntryId);
        return Ok();
    }

    [HttpGet("{listId:guid}")]
    public IActionResult GetAllMediaEntries(Guid listId)
    {
        IEnumerable<UserListItem> items = _service.GetListItems(listId);
        return Ok(items);
    }

    [HttpDelete("{listId:guid}/entries/{entryId:guid}")]
    public IActionResult RemoveEntry(Guid listId, Guid entryId)
    {
        _service.RemoveMediaFromList(listId, entryId);
        return NoContent();
    }
}
