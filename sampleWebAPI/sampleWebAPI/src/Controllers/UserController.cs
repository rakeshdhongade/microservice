using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace sampleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMongoDatabase mongoDatabase)
        {
            _logger = logger;
        }

        [HttpGet(Name = "User")]
        public IEnumerable<UserDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new UserDto
            {
                guid = Guid.NewGuid(),
                name = index.ToString(),
                mobile = "+91 12345678"+index.ToString(),
                vehicalnumber ="KA05 34354",
                Document = null,
                ProfilePhoto = null
            })
            .ToArray();
        }
    }
}