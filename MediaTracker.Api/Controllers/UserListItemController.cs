using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;

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
    public IActionResult Add(Guid listId, Guid mediaId)
    {
        _service.AddMediaToList(listId, mediaId);
        return Ok();
    }

    [HttpGet("{listId}")]
    public IActionResult Get(Guid listId)
    {
        var items = _service.GetListItems(listId);
        return Ok(items);
    }

    [HttpDelete]
    public IActionResult Remove(Guid listId, Guid mediaId)
    {
        _service.RemoveMediaFromList(listId, mediaId);
        return Ok();
    }
}
