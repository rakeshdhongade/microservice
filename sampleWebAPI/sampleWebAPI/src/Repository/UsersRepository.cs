using MongoDB.Driver;
using sampleWebAPI.Models;

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
                Document = user.Document,
                mobile = user.Mobile,
                Name = user.Name,
                ProfilePhoto = user.ProfilePhoto,
                vehicalnumber = user.VehicalNumber
            };
            await _collection.InsertOneAsync(userModel);
        }

    }
}
