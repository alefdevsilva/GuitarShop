using GuitarShop.Application.Interfaces;
using GuitarShop.Domain.Entities;
using GuitarShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GuitarShop.Infrastructure.Repositories;

public class GuitarRepository : IGuitarRepository
{
    private readonly AppDbContext _context;
    public GuitarRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Guitar>> GetAllAsync() => await _context.Guitars.ToListAsync();
    public async Task<Guitar?> GetByIdAsync(Guid id) => await _context.Guitars.FindAsync(id);
    public async Task AddAsync(Guitar guitar) => await _context.Guitars.AddAsync(guitar);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}