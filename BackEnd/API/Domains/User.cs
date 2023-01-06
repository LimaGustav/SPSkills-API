using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class User
    {
        public User()
        {
            Competitors = new HashSet<Competitor>();
        }

        public int Id { get; set; }
        public int IdUserType { get; set; }
        public int? IdSchool { get; set; }
        public int? IdSkill { get; set; }
        public string Name { get; set; } = null!;
        public string? Cpf { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? DeviceId { get; set; }

        public virtual School? IdSchoolNavigation { get; set; }
        public virtual Skill? IdSkillNavigation { get; set; }
        public virtual UserType IdUserTypeNavigation { get; set; } = null!;
        public virtual ICollection<Competitor> Competitors { get; set; }
    }
}
