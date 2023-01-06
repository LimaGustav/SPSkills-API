using API.Contexts;
using API.Domains;
using API.Interfaces;
using API.Utils;

namespace API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SpEntities ctx;
        public UsuarioRepository(SpEntities appContext)
        {
            ctx = appContext;
        }
        public User Login(string email, string password)
        {
            var usuario = ctx.Users.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Password.Length < 59)
                {
                    usuario.Password = Encript.GenerateHash(usuario.Password);

                    ctx.Users.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Encript.CompareHash(password, usuario.Password);

                if (comparado) return usuario;
            }
            return null;
        }

        public User SearchById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
