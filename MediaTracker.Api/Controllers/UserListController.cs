using Microsoft.AspNetCore.Mvc;
using MediaTracker.Domain.Services;

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
    public IActionResult Create(Guid userId, string name)
    {
        _userListService.CreateList(userId, name);
        return Ok();
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserLists(Guid userId)
    {
        var lists = _userListService.GetUserLists(userId);
        return Ok(lists);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _userListService.DeleteList(id);
        return Ok();
    }
}
