using GuitarShop.Domain.Entities;

namespace GuitarShop.Application.Interfaces;

public interface IGuitarRepository
{
    Task<IEnumerable<Guitar>> GetAllAsync();
    Task<Guitar?> GetByIdAsync(Guid id);
    Task AddAsync(Guitar guitar);
    Task SaveChangesAsync();
}