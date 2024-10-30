using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennosProducts.BusinessLogic.Data;
using TennosProducts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TennosProducts.BusinessLogic.Logic
{

    public class ProductoRepository<T> : IProductoRepository<T> where T : class
    {
        private readonly ProductoDbContext _context;
        private readonly DbSet<T> _Dbset;
        public ProductoRepository(ProductoDbContext context)
        {
            _Dbset = context.Set<T>();
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _Dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _Dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _Dbset.ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Dbset.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _Dbset.AddAsync(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
           
        }
    }
}
