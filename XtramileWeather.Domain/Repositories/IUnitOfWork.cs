namespace XtramileWeather.Domain.Repositories
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
