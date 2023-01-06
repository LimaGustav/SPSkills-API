using API.Domains;

namespace API.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Search for a user by its id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User whose Id is = id</returns>
        User SearchById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Login(string email, string password);
    }
}
