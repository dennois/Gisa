using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Repository
{
    public interface IConsultaFluxoRepository : IRepository<ConsultaFluxo>
    {
        public Task<IEnumerable<ConsultaFluxo>> RecuperarResumoAsync(long consultaIdentificador);
    }
}
