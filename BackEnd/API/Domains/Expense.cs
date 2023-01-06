using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class Expense
    {
        public int Id { get; set; }
        public int IdExpenseType { get; set; }
        public int IdCompetitor { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public virtual Competitor IdCompetitorNavigation { get; set; } = null!;
        public virtual ExpenseType IdExpenseTypeNavigation { get; set; } = null!;
    }
}
