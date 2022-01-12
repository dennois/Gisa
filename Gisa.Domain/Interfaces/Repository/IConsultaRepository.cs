using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Repository
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        public Task<IEnumerable<Consulta>> RecuperarResumoAsync(long usuarioIdentificador);

        public Task<IEnumerable<Consulta>> RecuperarResumoAsync(string conveniadoTipo,long? especialidade,string estado, string cidade, string status);
    }
}
