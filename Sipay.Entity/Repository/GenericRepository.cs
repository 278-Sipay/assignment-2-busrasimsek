﻿using Sipay.Core.Entity;
using Sipay.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay.Entity.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseEntity
    {
        private readonly SipayDbContext dbContext;
        public GenericRepository(SipayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            Delete(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }

        public IQueryable<Entity> GetAllAsQueryable()
        {
            return dbContext.Set<Entity>().AsQueryable();
        }

        public Entity GetById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            return entity;
        }

        public void Insert(Entity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedUser = "sipayadmin@pay.com";
            dbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            dbContext.Set<Entity>().Update(entity);
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> filter)
        {
            return dbContext.Set<Entity>().Where(filter).ToList();
        }
    }
}
