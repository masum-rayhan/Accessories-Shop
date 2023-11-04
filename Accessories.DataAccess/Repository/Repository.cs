using Accessories.DataAccess.Data;
using Accessories.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var data = await dbSet.ToListAsync();
        return data;
    }

    public async Task<T> GetDetailsAsync(int id)
    {
        var data = await dbSet.FindAsync(id);
        return data;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);

        return await query.FirstOrDefaultAsync();
    }

    public void RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRangeAsync(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }

    public Task SaveAsync()
    {
        return _db.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
