using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository
{
    public class FluxoRepository : BaseRepository<Fluxo>, IFluxoRepository
    {
        public FluxoRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
