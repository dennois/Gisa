using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Repository
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        public Task<IEnumerable<Consulta>> RecuperarResumoAsync(long usuarioIdentificador);
    }
}
