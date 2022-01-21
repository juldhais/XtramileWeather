using System;
using System.Collections.Generic;
using XtramileWeather.Domain.Entities.Abstractions;

namespace XtramileWeather.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(Guid id);
        List<T> GetAll();
        void Create(T entity, Guid? createdById);
        void Update(T entity, Guid? updatedById);
        void Delete(Guid id, Guid? deletedById);
    }
}
