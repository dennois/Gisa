using Gisa.Domain;
using Gisa.Domain.DTO;
using Gisa.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.SqlRepository
{
    public class ConveniadoRepository : BaseRepository<Conveniado>, IConveniadoRepository
    {
        public ConveniadoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IList<Conveniado>> RecuperarResumo(ConveniadoFiltro filtro)
        {
            Conveniado conveniado = new Conveniado();
            conveniado.Codigo = "1";
            IList<Conveniado> result = new List<Conveniado>();
            result.Add(conveniado);
            return result;
        }
    }
}
