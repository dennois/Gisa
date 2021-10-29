using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.SqlRepository
{
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
