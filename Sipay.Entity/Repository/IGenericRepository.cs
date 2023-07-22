using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay.Entity.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> filter);
        void Save();
        Entity GetById(int id);
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        void DeleteById(int id);
        List<Entity> GetAll();
        IQueryable<Entity> GetAllAsQueryable();
    }
}

