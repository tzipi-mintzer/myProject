using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;

        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Permission> AddAsync(int id, string name, string description)
        {
            var p = _context.Permissions.Add(new Permission() { Id = id, Name = name, Description = description });
            await _context.SaveChangesAsync();
            return p.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Permissions.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }

        public async Task<Permission> UpdateAsync(Permission Permission)
        {
            Permission r1 = GetByIdAsync(Permission.Id).Result;
            r1.Name = Permission.Name;
            r1.Description = Permission.Description;
            await _context.SaveChangesAsync();
            return r1;
        }
    }
}
