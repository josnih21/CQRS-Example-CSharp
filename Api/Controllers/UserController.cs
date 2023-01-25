using CQRS.Command;
using CQRS.Dispatcher;
using CQRS.Dto;
using CQRS.Query;
using CQRS.QueryHandler;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    readonly CommandBus _commandBus = new CommandBus();
    private readonly UserByEmailQueryHandler _userByEmailQueryHandler = new UserByEmailQueryHandler();

    [HttpGet($"{{email}}")]
    public String Get(string email)
    {
        var userByEmail = new UserByEmail(email);
        var userName = _userByEmailQueryHandler.Handle(userByEmail);
        return userName;
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto userDto)
    {
        var createUserCommand = new CreateUserCommand(userDto.userName, userDto.age, userDto.email);
        _commandBus.Dispatch(createUserCommand);
        return Ok();
    }
}