namespace sampleWebAPI;

public record UserDto(Guid Guid, string Name, string Mobile, string VehicalNumber, IFormFile Document, IFormFile ProfilePhoto);
//public class UserDto
//{
//    public Guid Guid { get; set; }
//    public string Name { get; set; }
//    public string Mobile { get; set; }
//    public string VehicalNumber { get; set; }
//    public IFormFile Document { get; set; }
//    public IFormFile ProfilePhoto { get; set; }

//    public UserDto(Guid guid, string name, string mobile, string vehicalNumber, IFormFile document, IFormFile profilePhoto)
//    {
//        Guid = guid;
//        Name = name;
//        Mobile = mobile;
//        VehicalNumber = vehicalNumber;
//        Document = document;
//        ProfilePhoto = profilePhoto;
//    }
//}