using API.Domains;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IFrequencyRepository
    {
        /// <summary>
        /// Get all Frequencies
        /// </summary>
        /// <returns></returns>
        List<Frequency> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        List<Frequency> GetBySkillId(int skillId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitorId"></param>
        /// <returns></returns>
        List<Frequency> GetByCompetitorId(int competitorId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Frequency> GetByUserId(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        bool RegisterFrequency(Frequency frequency);

        /// <summary>
        /// Updates a existing frequency
        /// </summary>
        /// <param name="idFrequency">Id of the frequency to be edited</param>
        /// <param name="newFrequency">Edited data of the Frequency</param>
        /// <returns></returns>
        Frequency UpdateFrequency(int idFrequency, Frequency newFrequency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        bool CheckInUser(int idUser, CheckViewModel check);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        bool CheckOutUser(int idUser, CheckViewModel check);
    }
}
