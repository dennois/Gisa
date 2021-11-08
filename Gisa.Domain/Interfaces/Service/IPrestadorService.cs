using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Service
{
    public interface IPrestadorService
    {
        public Task<Prestador> IncluirAsync(Prestador prestador);

        public Task<Prestador> AtualizarAsync(Prestador prestador);

        public Task<Prestador> RecuperarPorIdAsync(long entityId);

        public Task ExcluirAsync(long entityId);
    }
}
