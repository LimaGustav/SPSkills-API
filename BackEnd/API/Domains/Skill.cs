using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class Skill
    {
        public Skill()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
