namespace sampleWebAPI;

public record UserDto(Guid Guid, string Name, string Mobile, string VehicleNumber, IFormFile Document, IFormFile ProfilePhoto);