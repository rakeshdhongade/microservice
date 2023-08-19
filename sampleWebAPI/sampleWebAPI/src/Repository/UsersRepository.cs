using MongoDB.Driver;
using sampleWebAPI.Models;

namespace sampleWebAPI.src.Repository;

public class UsersRepository : IUsersRepository
{
    private IMongoCollection<UserModel> _collection;

    public UsersRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<UserModel>("VehicleUsers");
    }

    public async Task AddUserAsync(UserDto user)
    {
        var userModel = new UserModel()
        {
            Document = GetByte(user.Document),
            Mobile = user.Mobile,
            Name = user.Name,
            ProfilePhoto = GetByte(user.ProfilePhoto),
            Vehiclenumber = user.VehicleNumber
        };
        await _collection.InsertOneAsync(userModel);
    }

    public async Task DeleteUserAsync(Guid guid)
    {
        FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(v => v.Id, guid);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        List<UserModel> users;
        try
        {
            users = await _collection.Find(Builders<UserModel>.Filter.Empty).ToListAsync<UserModel>();
        }
        catch (Exception)
        {
            throw;
        }
        return users.Select(user => user.AsDto());
    }

    public async Task<UserDto> GetUserAsync(Guid guid)
    {
        List<UserModel> vehicles;
        try
        {
            FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Where(vehicle => vehicle.Id == guid);
            vehicles = await _collection.Find(Builders<UserModel>.Filter.Empty).ToListAsync<UserModel>();
        }
        catch (Exception)
        {
            throw;
        }
        return vehicles.First().AsDto();
    }

    public async Task UpdateUserAsync(Guid guid, UserDto user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(v => v.Id, user.Guid);
        var userModel = new UserModel()
        {
            Id = user.Guid,
            Mobile = user.Mobile,
            Name = user.Name,
            Vehiclenumber = user.VehicleNumber,
            Document = GetByte(user.Document),
            ProfilePhoto = GetByte(user.ProfilePhoto)
        };
        await _collection.ReplaceOneAsync(filter, userModel);
    }

    private byte[] GetByte(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
