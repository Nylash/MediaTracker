using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;
using MediaTracker.Domain.Entities;

namespace MediaTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserListController : ControllerBase
{
    private readonly UserListService _userListService;

    public UserListController(UserListService userListService)
    {
        _userListService = userListService;
    }

    [HttpPost]
    public IActionResult CreateList(Guid userId, string listName)
    {
        _userListService.CreateList(userId, listName);
        return Ok();
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserLists(Guid userId)
    {
        IEnumerable<UserList> lists = _userListService.GetUserLists(userId);
        return Ok(lists);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteList(Guid id)
    {
        _userListService.DeleteList(id);
        return Ok();
    }
}
