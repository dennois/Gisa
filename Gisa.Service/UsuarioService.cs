using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository, IAtenticacaoService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        readonly IUsuarioRepository _usuarioRepository;
        readonly IAtenticacaoService _tokenService;

        public Task<Usuario> AtualizarAsync(Usuario associado)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> IncluirAsync(Usuario associado)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> RecuperarAsync(string usuario, string senha)
        {
            string senhaCriptografada = _tokenService.CriptografarSenha(senha);
            return await _usuarioRepository.RecuperarPorLogin(usuario, senhaCriptografada);
        }

        public Task<Usuario> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
