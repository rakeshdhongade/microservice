using MongoDB.Bson.Serialization.Attributes;

namespace sampleWebAPI.Models;

public class UserModel
{
    [BsonId]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string mobile { get; set; }
    public string vehicalnumber { get; set; }
    public IFormFile Document { get; set; }
    public IFormFile ProfilePhoto { get; set; }
}
