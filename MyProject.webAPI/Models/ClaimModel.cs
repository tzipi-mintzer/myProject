using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.webAPI.Models
{
    public enum EPolicy { Allow, Deny}

    public class ClaimModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public EPolicy Policy { get; set; }
    }
}
