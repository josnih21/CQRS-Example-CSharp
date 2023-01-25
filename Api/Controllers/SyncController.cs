using CQRS.EventHandler;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
/// <summary>
/// This class aims to sync the Write Model with the Read Model normaly this will be a separataly program or solution that
/// allows to synchronize the models on each startup. 
/// </summary>
[ApiController]
[Route("[controller]")]
public class SyncController : ControllerBase
{
    private readonly UserSynchronizer _userSynchronizer = new UserSynchronizer();

    [HttpPost]
    public void Post()
    {
        _userSynchronizer.syncAll();
    }
}