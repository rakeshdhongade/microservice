using MongoDB.Bson.Serialization.Attributes;

namespace sampleWebAPI.Models;

public class UserModel
{
    [BsonId]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Vehiclenumber { get; set; }
    public byte[] Document { get; set; }
    public byte[] ProfilePhoto { get; set; }
}
