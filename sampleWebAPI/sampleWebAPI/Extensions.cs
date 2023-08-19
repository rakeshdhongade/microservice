using sampleWebAPI.Models;
using sampleWebAPI.src.Models;
using System.Runtime.CompilerServices;

namespace sampleWebAPI;

public static class Extensions
{
    public static UserDto AsDto(this UserModel user)
    {
        return new UserDto(user.Id, user.Name, user.Mobile, user.Vehiclenumber,
            ToIFromFile(user.Document, "document"), ToIFromFile(user.ProfilePhoto, "profilephoto"));
    }

    public static VehicleDto AsDto(this VehicleModel vehicle)
    {
        return new VehicleDto(vehicle.Id, vehicle.Number, vehicle.Location, vehicle.Battery, vehicle.Health);
    }

    private static IFormFile ToIFromFile(byte[] document, string type)
    {
        using var stream = new MemoryStream(document);
        FormFile file = null;
        if (type == "document")
        {
            file = new FormFile(stream, 0, document.Length, "download1", $"download1.jpg");
            file.Headers = new HeaderDictionary();
            file.ContentDisposition = @"form-data; name=""Document""; filename=""download1.jpg""";
            file.ContentType = "image/jpeg";
        }
        else if(type == "profilephoto")
        {
            file = new FormFile(stream, 0, document.Length, "download", $"download.jpg");
            file.Headers = new HeaderDictionary();
            file.ContentDisposition = @"form-data; name=""ProfilePhoto""; filename=""download.jpg""";
            file.ContentType = "image/jpeg";

        }
        return file;
    }
}
