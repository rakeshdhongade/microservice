using MongoDB.Bson.Serialization.Attributes;

namespace sampleWebAPI.src.Models;

public class VehicleModel
{
    [BsonId]
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Location { get; set; }
    public int Battery { get; set; }
    public string Health { get; set; }
}
