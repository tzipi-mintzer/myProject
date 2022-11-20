using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class ClaimRepository : IclaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public Claim Add(int id, int roleId, int  permissionId,EPolicy ePolicy)
        {
            Claim c = new Claim() { Id = id, RoleId=roleId,PermissionId=permissionId,Policy=ePolicy};
            _context.Claims.Add(c);
            return c;
        }

  


        public void Delete(int id)
        {
            _context.Claims.Remove(GetById(id));
        }

        public List<Claim> GetAll()
        {
            return _context.Claims;
        }

        public Claim GetById(int id)
        {
            return _context.Claims.Find(c => c.Id == id);
        }

        public Claim Update(Claim claim)
        {
            Claim c1 = GetById(claim.Id);
            c1.RoleId = claim.RoleId;
            c1.PermissionId = claim.PermissionId;
            c1.Policy = claim.Policy;
            return c1;
        }
    }
}
