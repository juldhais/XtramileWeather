using System;
using System.Collections.Generic;
using XtramileWeather.Domain.Entities.Abstractions;

namespace XtramileWeather.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();
    }
}
