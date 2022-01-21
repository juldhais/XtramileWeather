using Microsoft.EntityFrameworkCore;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Persistence.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
    }
}
