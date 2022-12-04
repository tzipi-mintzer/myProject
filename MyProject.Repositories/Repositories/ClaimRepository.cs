﻿using Microsoft.EntityFrameworkCore;
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
            var c = _context.Claims.Add(new Claim() { Id = id,/*, RoleId=roleId,PermissionId=permissionId,*/Policy=ePolicy});
            await _context.SaveChangesAsync();
            return c.Entity;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Claims.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Claim>> GetAllAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claim> GetByIdAsync(int id)
        {
            return await _context.Claims.FindAsync(id);
        }

        public async Task<Claim> UpdateAsync(Claim claim)
        {
            Claim c1 = GetByIdAsync(claim.Id).Result;
            c1.Role.Id = claim.Role.Id;
            c1.Permission.Id = claim.Permission.Id;
            c1.Policy = claim.Policy;
            await _context.SaveChangesAsync();
            return c1;
        }

      
    }
}
