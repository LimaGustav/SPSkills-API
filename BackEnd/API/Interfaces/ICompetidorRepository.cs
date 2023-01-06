using API.Domains;

namespace API.Interfaces
{
    public interface ICompetidorRepository
    {
        /// <summary>
        /// Gets a competitor by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A User</returns>
        Competitor GetById(int id);

        /// <summary>
        /// Gets a competitor by its user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Competitor GetByUserId(int userId);

        /// <summary>
        /// Gets all Competitors
        /// </summary>
        /// <returns>Competitors List</returns>
        List<Competitor> GetAll();
    }
}
