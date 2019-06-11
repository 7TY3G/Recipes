using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recipes.Data.DataModels;
using Recipes.Domain.Repositories;

namespace Recipes.Data.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        private readonly RecipesContext dbContext;

        public BaseRepository(RecipesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Add(Entity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual IEnumerable<Entity> Get()
        {
            return dbContext.Set<Entity>().AsNoTracking();
        }

        public virtual Entity GetById(int id)
        {
            return dbContext.Set<Entity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual void Update(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
