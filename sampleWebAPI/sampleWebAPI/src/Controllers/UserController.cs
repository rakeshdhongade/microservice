using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using sampleWebAPI.Models;
using sampleWebAPI.src.Repository;

namespace sampleWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly ILogger<UserController> _logger;
    private readonly IUsersRepository _usersRepository;

    public UserController(ILogger<UserController> logger, IUsersRepository usersRepository)
    {
        _logger = logger;
        this._usersRepository = usersRepository;
    }

    [HttpGet(Name = "User")]
    public IEnumerable<UserDto> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new UserDto
        {
            Guid = Guid.NewGuid(),
            Name = index.ToString(),
            Mobile = "+91 12345678"+index.ToString(),
            VehicalNumber ="KA05 34354",
            Document = null,
            ProfilePhoto = null
        })
        .ToArray();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsynch(UserDto userDto)
    {
       await _usersRepository.AddUserAsync(userDto);

        return NoContent();
    }
}