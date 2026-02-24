using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Repositories;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserListRepository _userListRepository;

    public UserService(
        IUserRepository userRepository,
        IUserListRepository userListRepository)
    {
        _userRepository = userRepository;
        _userListRepository = userListRepository;
    }

    public User Create(string username, string email)
    {
        var user = new User(username, email);

        _userRepository.Add(user);

        foreach (MediaCategory category in Enum.GetValues(typeof(MediaCategory)))
        {
            var defaultList = new UserList(user.Id, category);
            _userListRepository.Add(defaultList);
        }

        return user;
    }
}