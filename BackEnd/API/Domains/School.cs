using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class School
    {
        public School()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Logitude { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
