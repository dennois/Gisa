using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class FluxoService : IFluxoService
    {
        public FluxoService(IFluxoRepository fluxoRepository)
        {
            _fluxoRepository = fluxoRepository;
        }

        readonly IFluxoRepository _fluxoRepository;

        public async Task<Fluxo> IncluirAsync(Fluxo fluxo)
        {
            return await _fluxoRepository.IncluirAsync(fluxo);
        }
    }
}
