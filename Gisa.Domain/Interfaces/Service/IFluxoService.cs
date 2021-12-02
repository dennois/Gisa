using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Service
{
    public interface IFluxoService
    {
        public Task<Fluxo> IncluirAsync(Fluxo fluxo);
    }
}
