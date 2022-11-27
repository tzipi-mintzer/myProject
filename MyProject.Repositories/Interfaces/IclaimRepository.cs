﻿using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IClaimRepository
    {
        Task<List<Claim>> GetAllAsync();

        Task<Claim> GetByIdAsync(int id);

        Task<Claim> AddAsync(int id, int roleId, int permissionId, EPolicy ePolicy);

        Task<Claim> UpdateAsync(Claim Claim);

        Task DeleteAsync(int id);
    }
}
