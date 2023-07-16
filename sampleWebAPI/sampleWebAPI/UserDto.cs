namespace sampleWebAPI;

public class UserDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string VehicalNumber { get; set; }
    public IFormFile Document { get; set; }
    public IFormFile ProfilePhoto { get; set; }
}