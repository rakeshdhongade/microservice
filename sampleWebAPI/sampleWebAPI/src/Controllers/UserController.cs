using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get()
    {
        return await _usersRepository.GetAllUsersAsync();
    }
    [HttpGet("{guid}")]
    public async Task<UserDto> Get(Guid guid)
    {
        return await _usersRepository.GetUserAsync(guid);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm] UserDto userDto)
    {
        try
        {
            _logger.Log(LogLevel.Information, $"Document.ContentDisposition : {userDto.Document.ContentDisposition}," +
                $" {userDto.Document.ContentType}"); 
            await _usersRepository.AddUserAsync(userDto);
        }
        catch (Exception)
        {
            _logger.Log(LogLevel.Error, "exception while upload the file");
        }
        return Ok();
    }

    [HttpPut("{guid}")]
    public async Task Put(Guid guid, [FromBody] UserDto user)
    {
        await _usersRepository.UpdateUserAsync(guid, user);
    }

    // DELETE api/<VehicleController>/5
    [HttpDelete("{guid}")]
    public async Task Delete(Guid guid)
    {
        await _usersRepository.DeleteUserAsync(guid);
    }
}