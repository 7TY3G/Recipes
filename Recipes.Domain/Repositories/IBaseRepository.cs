using System.Collections.Generic;

namespace Recipes.Domain.Repositories
{
    public interface IBaseRepository<BaseEntity> where BaseEntity : class
    {
        void Add(BaseEntity entity);

        void Delete(int id);

        IEnumerable<BaseEntity> Get();

        BaseEntity GetById(int id);

        void Update(BaseEntity entity);
    }
}
