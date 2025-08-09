using SimpleUser.Domain.Entities;
using SimpleUser.Domain.Interfaces;
using SimpleUser.Application.DTOs;

namespace SimpleUser.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var list = await _usuarioRepository.GetAllAsync();
            return list.OrderBy( comparer => comparer.Nome );
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(UsuarioDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                Telefone = usuarioDto.Telefone,
                Endereco = usuarioDto.Endereco,
                DataNascimento = usuarioDto.DataNascimento
            };

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;
            usuario.Telefone = usuarioDto.Telefone;
            usuario.Endereco = usuarioDto.Endereco;
            usuario.DataNascimento = usuarioDto.DataNascimento;

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
