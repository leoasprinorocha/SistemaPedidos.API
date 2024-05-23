using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities.Usuario;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaPedidosContext _context;

        public UsuarioRepository(SistemaPedidosContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CadastraNovoUsuario(Usuario usuario)
        {
            try
            {
                var adesao = await _context.Adesao.FirstOrDefaultAsync(c => c.Id == usuario.IdAdesao);
                if (adesao is not null)
                    usuario.AdesaoUsuario = adesao;

                await _context.Usuario.AddAsync(usuario);

                var salvo = await _context.SaveChangesAsync();
                if (salvo > 0)
                    return await RecuperaUsuarioPeloLogin(usuario.Email);
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<Guid> RecuperaIdAdesaoPorIdAspnetUser(Guid idAspnetUser)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(c => c.IdAspnetUser == idAspnetUser);
            if (usuario is not null)
                return usuario.IdAdesao;
            return Guid.Empty;
        }

        public async Task<List<Usuario>> RecuperaTodosUsuariosAdesao(Guid idAdesao)
        {
            var usuariosAdesao = await _context.Usuario.AsNoTracking().Where(c => c.IdAdesao == idAdesao).ToListAsync();
            return usuariosAdesao;
        }

        public async Task<Usuario> RecuperaUsuarioPeloLogin(string login) =>
            await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(c => c.Email.Equals(login));


    }
}
