using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public enum EPolicyDTO { Allow, Deny}

    public class ClaimDTO
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public EPolicyDTO Policy { get; set; }    }
}
