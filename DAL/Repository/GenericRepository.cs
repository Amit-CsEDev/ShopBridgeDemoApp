using DAL.IRepository;
using DAL.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext dbContext;
        private DbSet<T> entities;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }
        public async Task<int> DeleteAsync(T obj)
        {
            dbContext.Set<T>().Remove(obj);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int? id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> InsertAsync(T obj)
        {
            dbContext.Set<T>().Add(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }
        public async Task<T> InsertAllAsync(ICollection<T> obj)
        {
            await dbContext.Set<T>().AddRangeAsync(obj);
            dbContext.SaveChanges();
            return obj.FirstOrDefault();
        }
        public async Task<T> UpdateAsync(T obj, object key)
        {
            if (obj == null)
                return null;
            T exist = await dbContext.Set<T>().FindAsync(key);
            if (exist != null)
            {
                dbContext.Entry(exist).CurrentValues.SetValues(obj);
                await dbContext.SaveChangesAsync();
            }
            return exist;
        }

    }
}
