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
        List<ClaimDTO> GetAll();

        ClaimDTO GetById(int id);

        ClaimDTO Add(int id, int roleId, int permissionId, EPolicyDTO ePolicy);

        ClaimDTO Update(ClaimDTO Claim);

        void Delete(int id);
    }
}
