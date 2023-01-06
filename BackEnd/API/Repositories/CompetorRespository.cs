using API.Contexts;
using API.Domains;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories
{

    public class CompetorRespository : ICompetidorRepository
    {

        private readonly SpEntities ctx = new SpEntities();

        public Competitor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Competitor GetByUserId(int userId)
        {
            var competidor = ctx.Competitors.FirstOrDefault(x => x.IdUser == userId);
            return competidor;

        }

        List<Competitor> ICompetidorRepository.GetAll()
        {
            return ctx.Competitors.ToList();
        }
    }
}
