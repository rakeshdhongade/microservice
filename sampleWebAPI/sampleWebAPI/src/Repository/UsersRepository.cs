using MongoDB.Driver;
using sampleWebAPI.Models;
using System;

namespace sampleWebAPI.src.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private IMongoCollection<UserModel> _collection;

        public UsersRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<UserModel>("VehicalUsers");
        }

        public async Task AddUserAsync(UserDto user)
        {
            var userModel = new UserModel()
            {
                Document = GetByte(user.Document),
                Mobile = user.Mobile,
                Name = user.Name,
                ProfilePhoto = GetByte(user.ProfilePhoto),
                Vehicalnumber = user.VehicalNumber
            };
            await _collection.InsertOneAsync(userModel);
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

        private byte[] GetByte(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
