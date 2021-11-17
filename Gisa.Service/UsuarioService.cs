using Gisa.Domain;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class UsuarioService : IUsuarioService
    {
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
            return new Usuario() { Nome = "Dennis Molina", Login = usuario, Senha = senha , Perfil = "Admin"};
        }

        public Task<Usuario> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
