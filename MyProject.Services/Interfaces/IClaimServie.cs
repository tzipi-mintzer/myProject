using MyProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IClaimService
    {
        Task<List<ClaimDTO>> GetAllAsync();

        Task<ClaimDTO> GetByIdAsync(int id);

        Task<ClaimDTO> AddAsync(int id, int roleId, int permissionId, EPolicyDTO ePolicy);

        Task<ClaimDTO> UpdateAsync(ClaimDTO Claim);

        Task DeleteAsync(int id);
    }
}
