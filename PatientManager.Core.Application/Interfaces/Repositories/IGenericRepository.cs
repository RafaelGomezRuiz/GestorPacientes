using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity>
        where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task UpdateAsync(Entity entity, int id);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync (int id);
        Task<IEnumerable<Entity>> GetAllWithIncludeAsync(IEnumerable<string> properties);
    }
}
