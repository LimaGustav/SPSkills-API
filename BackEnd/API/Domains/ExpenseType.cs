using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
