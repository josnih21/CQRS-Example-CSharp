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
    private IMessageSession _messageSession;
    private readonly UserByEmailUseCase _userByEmailUseCase = new UserByEmailUseCase();

    public UserController(IMessageSession messageSession)
    {
        _messageSession = messageSession;
    }


    [HttpGet($"{{email}}")]
    public String Get(string email)
    {
        var userByEmail = new UserByEmail(email);
        return _userByEmailUseCase.Execute(userByEmail.Email);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto userDto)
    {
        var createUserCommand = new CreateUserCommand{UserName = userDto.userName, Age = userDto.age, Email = userDto.email};
        await _messageSession.Send(createUserCommand).ConfigureAwait(false);
        Console.WriteLine("Message sent to NServiceBus");
        return Ok();
    }
}