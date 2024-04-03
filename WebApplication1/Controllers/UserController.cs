using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private static List<User> _userList = new()
    {
        new ()
        {
            Id = "0059ae90-57f3-4b5a-b5ae-e854b51e6349",
            Name = "Edmond"
        }
    };

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        var result = _userList.SingleOrDefault(x => x.Id == id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] PostUserRequest requestModel)
    {
        // todo validation
        var userEntity = new User()
        {
            Id = Guid.NewGuid().ToString(),
            Name = requestModel.Name
        };
        _userList.Add(userEntity);
        
        return Ok(new PostUserResponse()
        {
            Id = userEntity.Id,
            Name = userEntity.Name
        });
    }
}