using XtramileWeather.Domain.Entities;

namespace XtramileWeather.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
    }
}
