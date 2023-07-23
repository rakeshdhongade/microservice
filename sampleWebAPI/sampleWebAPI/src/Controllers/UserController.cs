using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using sampleWebAPI.Models;
using sampleWebAPI.src.Repository;

namespace sampleWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUsersRepository _usersRepository;

    public UserController(ILogger<UserController> logger, IUsersRepository usersRepository)
    {
        _logger = logger;
        this._usersRepository = usersRepository;
    }

    [HttpGet(Name = "Users")]
    public async Task<IEnumerable<UserDto>> Get()
    {
        return await _usersRepository.GetAllUsersAsync();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm] UserDto userDto)
    {
        try
        {
            await _usersRepository.AddUserAsync(userDto);
        }
        catch (Exception)
        {
            _logger.Log(LogLevel.Error, "exception while upload the file");
        }
        return Ok();
    }
}