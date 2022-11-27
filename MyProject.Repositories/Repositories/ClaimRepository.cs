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
   public class ClaimRepository : IClaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        } 

        public async Task<Claim> AddAsync(int id, int roleId, int  permissionId,EPolicy ePolicy)
        {
            var c = _context.Claims.Add(new Claim() { Id = id, RoleId=roleId,PermissionId=permissionId,Policy=ePolicy});
            await _context.SaveGangesAsync();
            return c.Entity;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Claims.Remove(GetByIdAsync(id).Result);
            await _context.SaveGangesAsync();
        }

        public async Task<List<Claim>> GetAllAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claim> GetByIdAsync(int id)
        {
            return await _context.Claims.FindAsync(id);
        }

        public async Task<Claim> Update(Claim claim)
        {
            Claim c1 = GetByIdAsync(claim.Id).Result;
            c1.RoleId = claim.RoleId;
            c1.PermissionId = claim.PermissionId;
            c1.Policy = claim.Policy;
            await _context.SaveGangesAsync();
            return c1;
        }
    }
}
