using CQRS.Command;
using CQRS.Dispatcher;
using CQRS.Dto;
using CQRS.Query;
using CQRS.QueryHandler;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

//TODO: Refactor create controller for each endpoint
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    readonly CommandBus _commandBus = new CommandBus();
    private readonly UserByEmailUseCase _userByEmailUseCase = new UserByEmailUseCase();


    [HttpGet($"{{email}}")]
    public String Get(string email)
    {
        var userByEmail = new UserByEmail(email);
        return _userByEmailUseCase.Execute(userByEmail.Email);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto userDto)
    {
        var createUserCommand = new CreateUserCommand(userDto.userName, userDto.age, userDto.email);
        _commandBus.Dispatch(createUserCommand);
        return Ok();
    }
}