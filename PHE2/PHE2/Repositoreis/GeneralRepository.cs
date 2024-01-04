using PHE2.Contratcs;
using PHE2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.Repositoreis
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly Phe2DbContext _context;

        public GeneralRepository(Phe2DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>()
                           .ToList();
        }

        public TEntity GetByGuid(Guid guid)
        {
            var data = _context.Set<TEntity>()
                               .Find(guid);

            if (data != null)
            {
                _context.Entry(data).State = EntityState.Detached;
            }

            return data;
        }

        public TEntity Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>()
                        .Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity)
                        .State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>()
                        .Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Clear()
        {
            foreach (var entry in _context.ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}