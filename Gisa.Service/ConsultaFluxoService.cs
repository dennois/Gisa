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

        public async Task<ConsultaFluxo> AtualizarAsync(ConsultaFluxo consultaFluxo)
        {
            string status = consultaFluxo.Status;
            consultaFluxo = await _consultaFluxoRepository.RecuperarPorIdAsync(consultaFluxo.Identificador);
            consultaFluxo.Status = status;
            consultaFluxo.DataFim = DateTime.UtcNow;
            consultaFluxo = await _consultaFluxoRepository.AtualizarAsync(consultaFluxo);
            var consultaProximo = await this.RecuperarProximoAsync(consultaFluxo.Identificador, consultaFluxo.Consulta);
            if(consultaProximo != null)
            {
                consultaProximo.Status = "E";
                consultaProximo.DataInicio = DateTime.UtcNow;
                await _consultaFluxoRepository.AtualizarAsync(consultaProximo);
            }
            return consultaFluxo;
        }

        public async Task<ConsultaFluxo> IncluirAsync(ConsultaFluxo consultaFluxo)
        {
            return await _consultaFluxoRepository.IncluirAsync(consultaFluxo);
        }

        public async Task<IEnumerable<ConsultaFluxo>> RecuperarResumoAsync(long consultaIdentificador)
        {
            return await _consultaFluxoRepository.RecuperarResumoAsync(consultaIdentificador);
        }

        public async Task<ConsultaFluxo> RecuperarProximoAsync(long identificador, long consulta)
        {
            return await _consultaFluxoRepository.RecuperarProximoAsync(identificador, consulta);
        }
    }
}
