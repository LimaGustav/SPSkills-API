using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class Competitor
    {
        public Competitor()
        {
            Expenses = new HashSet<Expense>();
            Frequencies = new HashSet<Frequency>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Frequency> Frequencies { get; set; }
    }
}
