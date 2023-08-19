namespace sampleWebAPI.src.Repository;
public interface IUsersRepository
{
    Task AddUserAsync(UserDto user);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserAsync(Guid guid);
    Task UpdateUserAsync(Guid guid, UserDto user);
    Task DeleteUserAsync(Guid guid);
}