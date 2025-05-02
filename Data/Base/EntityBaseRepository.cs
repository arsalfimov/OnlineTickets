using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OnlineTickets.Data.Base;

public class EntityBaseRepository<T>(AppDbContext context) : IEntityBaseRepository<T>
    where T : class, IEntityBase, new()
{

    public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] inculdeProperties)
    {
        IQueryable<T> query = context.Set<T>();
        query = inculdeProperties.Aggregate(query, (current, inculdProperty) => current.Include(inculdProperty));
        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T entity)
    {
        entity.Id = id;
        EntityEntry entityEntry = context.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        EntityEntry entityEntry = context.Entry<T>(entity);
        entityEntry.State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }
}