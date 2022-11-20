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

        public Permission Add(int id, string name, string description)
        {
            Permission p = new Permission() { Id = id, Name = name, Description = description };
            _context.Permissions.Add(p);
            return p;
        }

        public void Delete(int id)
        {
            _context.Permissions.Remove(GetById(id));
        }

        public List<Permission> GetAll()
        {
            return _context.Permissions;
        }

        public Permission GetById(int id)
        {
            return _context.Permissions.Find(r => r.Id == id);
        }

        public Permission Update(Permission Permission)
        {
            Permission r1 = GetById(Permission.Id);
            r1.Name = Permission.Name;
            r1.Description = Permission.Description;
            return r1;
        }
    }
}
