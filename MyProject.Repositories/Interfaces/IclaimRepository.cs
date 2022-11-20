using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IclaimRepository
    {
        List<Claim> GetAll();

        Claim GetById(int id);

        Claim Add(int id, int roleId, int permissionId, EPolicy ePolicy);

        Claim Update(Claim Claim);

        void Delete(int id);
    }
}
