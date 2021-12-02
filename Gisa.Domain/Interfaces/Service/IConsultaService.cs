using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Service
{
    public interface IConsultaService
    {
        public Task<Consulta> AgendarAsync(Consulta consulta);

        public Task<Consulta> AtualizarAsync(Consulta consulta);

        public Task<Consulta> RecuperarPorIdAsync(long entityId);

        public Task<IEnumerable<Consulta>> RecuperarResumoAsync(long usuarioIdentificador);
    }
}
