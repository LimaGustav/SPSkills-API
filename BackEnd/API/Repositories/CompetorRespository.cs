using API.Contexts;
using API.Domains;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var competidor = ctx.Competitors.Select(x => new Competitor()
            {
                Id = x.Id,
                IdUser = x.IdUser,
                Image = x.Image,
                Description = x.Description,
                Birthday = x.Birthday,
                IdUserNavigation = new User()
                {
                    IdUserType = x.IdUserNavigation.IdUserType,
                    IdSchool = x.IdUserNavigation.IdSchool,
                    IdSkill = x.IdUserNavigation.IdSkill,
                    Name = x.IdUserNavigation.Name,
                    Cpf = x.IdUserNavigation.Cpf,
                    Email = x.IdUserNavigation.Email,
                    DeviceId = x.IdUserNavigation.DeviceId,
                }
            }).FirstOrDefault(x => x.IdUser == userId);
            return competidor;

        }

        List<Competitor> ICompetidorRepository.GetAll()
        {
            return ctx.Competitors.Select(x => new Competitor()
            {
                Id = x.Id,
                IdUser = x.IdUser,
                Image = x.Image,
                Description = x.Description,
                Birthday = x.Birthday,
                IdUserNavigation = new User()
                {
                    IdUserType = x.IdUserNavigation.IdUserType,
                    IdSchool = x.IdUserNavigation.IdSchool,
                    IdSkill = x.IdUserNavigation.IdSkill,
                    Name = x.IdUserNavigation.Name,
                    Cpf = x.IdUserNavigation.Cpf,
                    Email = x.IdUserNavigation.Email,
                    DeviceId = x.IdUserNavigation.DeviceId,
                }
            }).ToList();
        }
    }
}
