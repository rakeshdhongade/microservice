namespace sampleWebAPI.src.Repository
{
    public interface IUsersRepository
    {
        public Task AddUserAsync(UserDto user);
    }
}