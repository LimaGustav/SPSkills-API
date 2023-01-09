using API.Contexts;
using API.Domains;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly SpEntities ctx = new SpEntities();
        public List<Frequency> GetAll()
        {
            return ctx.Frequencies.Include(x => x.IdCompetitorNavigation).ToList();
        }

        public List<Frequency> GetByCompetitorId(int competitorId)
        {
            return ctx.Frequencies.Where(x => x.IdCompetitor == competitorId).Include(x => x.IdCompetitorNavigation).ToList();
        }

        public List<Frequency> GetByUserId(int userId)
        {
            try
            {
                Competitor comp = ctx.Competitors.Where(x => x.IdUser == userId).First();
                return ctx.Frequencies.Where(x => x.IdCompetitor == comp.Id).Include(x => x.IdCompetitorNavigation).ToList();

            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<Frequency> GetBySkillId(int skillId)
        {
            throw new NotImplementedException();
        }

        public bool RegisterFrequency(Frequency frequency)
        {
            try
            {
                ctx.Frequencies.Add(frequency);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public Frequency UpdateFrequency(int idFrequency, Frequency newFrequency)
        {
            try
            {
                var searchedFrequency = ctx.Frequencies.Find(idFrequency);
                searchedFrequency.CheckIn = newFrequency.CheckIn;
                searchedFrequency.CheckOut = newFrequency.CheckOut;
                searchedFrequency.Descricao = newFrequency.Descricao;
                ctx.Update(searchedFrequency);
                ctx.SaveChanges();
                return searchedFrequency;
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
    }
}
