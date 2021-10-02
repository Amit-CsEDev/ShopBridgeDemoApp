using BAL.IBusinessManager;
using DAL.IRepository;
using DAL.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BusinessManager
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        private ApplicationDbContext dbContext;
        private DbSet<T> entities;
        private readonly IGenericRepository<T> _iGenericRepository;
        public GenericManager(IGenericRepository<T> _iGenericRepository)
        {
            this._iGenericRepository = _iGenericRepository;
        }
        public async Task<int> DeleteAsync(T obj)
        {
            return await _iGenericRepository.DeleteAsync(obj);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _iGenericRepository.GetAllAsync();
        }
        public async Task<T> GetByIdAsync(int? id)
        {
            return await _iGenericRepository.GetByIdAsync(id);
        }
        public async Task<T> InsertAsync(T obj)
        {
            return await _iGenericRepository.InsertAsync(obj);
        }
        public async Task<T> InsertAllAsync(ICollection<T> obj)
        {
            return await _iGenericRepository.InsertAllAsync(obj);
        }
        public async Task<T> UpdateAsync(T obj, object key)
        {
            return await _iGenericRepository.UpdateAsync(obj, key);
        }
    }
}
