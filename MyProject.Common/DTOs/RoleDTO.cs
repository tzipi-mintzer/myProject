using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Role: Id = {Id}, Name = {Name}";
        }

    }
}
