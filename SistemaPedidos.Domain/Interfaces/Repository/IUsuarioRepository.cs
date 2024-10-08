﻿using SistemaPedidos.Domain.Entities.Pedidos;
using SistemaPedidos.Domain.Entities.Usuario;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> RecuperaUsuarioPeloLogin(string login);
        Task<Usuario> CadastraNovoUsuario(Usuario usuario);
        Task<Tuple<Guid, string>> RecuperaIdAdesaoENomePorIdAspnetUser(Guid idAspnetUser);

        Task<List<Usuario>> RecuperaTodosUsuariosAdesao(Guid idAdesao);
        
    }
}
