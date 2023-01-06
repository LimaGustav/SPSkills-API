using System;
using System.Collections.Generic;

namespace API.Domains
{
    public partial class Frequency
    {
        public int Id { get; set; }
        public int? IdCompetitor { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Competitor? IdCompetitorNavigation { get; set; }
    }
}
