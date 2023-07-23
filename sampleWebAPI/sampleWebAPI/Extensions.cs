using sampleWebAPI.Models;
using System.Runtime.CompilerServices;

namespace sampleWebAPI
{
    public static class Extensions
    {
        public static UserDto AsDto(this UserModel user)
        {
            return new UserDto(user.Id, user.Name, user.Mobile, user.Vehicalnumber,
                ToIFromFile(user.Document, "Document"), ToIFromFile(user.ProfilePhoto, "ProfilePhoto"));
        }

        private static IFormFile ToIFromFile(byte[] document, string fileName)
        {
            using var stream = new MemoryStream(document);
            return new FormFile(stream, 0, document.Length, fileName, $"{fileName}.png");
        }
    }
}
