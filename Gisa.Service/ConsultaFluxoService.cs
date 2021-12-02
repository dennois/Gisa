using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class ConsultaFluxoService : IConsultaFluxoService
    {
        public ConsultaFluxoService(IConsultaFluxoRepository consultaFluxoRepository)
        {
            _consultaFluxoRepository = consultaFluxoRepository;
        }

        readonly IConsultaFluxoRepository _consultaFluxoRepository;

        public Task<ConsultaFluxo> AtualizarAsync(ConsultaFluxo associado)
        {
            throw new NotImplementedException();
        }

        public Task<ConsultaFluxo> IncluirAsync(ConsultaFluxo consultaFluxo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ConsultaFluxo>> RecuperarResumoAsync(long consultaIdentificador)
        {
            return await _consultaFluxoRepository.RecuperarResumoAsync(consultaIdentificador);
        }
    }
}
