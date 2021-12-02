using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Integration;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class ConsultaService : IConsultaService
    {
        #region [ Construtor ]

        public ConsultaService(IConsultaRepository consultaRepository, IValidator<Consulta> consultaValidator, 
            IAssociadoService associadoService, 
            IEspecialidadeService especialidadeService, 
            IConveniadoService conveniadoService, 
            IPrestadorService prestadorService,
            IConsultarIntegration consultarIntegration,
            IFluxoService fluxoService,
            IConsultaFluxoService consultaFluxoService)
        {
            _consultaRepository = consultaRepository;
            _consultaValidator = consultaValidator;
            _associadoService = associadoService;
             _especialidadeService = especialidadeService;
            _conveniadoService = conveniadoService;
            _prestadorService = prestadorService;
            _consultarIntegration = consultarIntegration;
            _consultaFluxoService = consultaFluxoService;
            _fluxoService = fluxoService;
        }

        #endregion

        #region [ Membros ]

        readonly IConsultaRepository _consultaRepository;
        readonly IValidator<Consulta> _consultaValidator;
        readonly IAssociadoService _associadoService;
        readonly IEspecialidadeService _especialidadeService;
        readonly IConveniadoService _conveniadoService;
        readonly IPrestadorService _prestadorService;
        readonly IConsultarIntegration _consultarIntegration;
        readonly IConsultaFluxoService _consultaFluxoService;
        readonly IFluxoService _fluxoService;

        #endregion

        #region [ Métodos ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public async Task<Consulta> AgendarAsync(Consulta consulta)
        {
            var validate =_consultaValidator.Validate(consulta);
            if (validate.IsValid)
            {
                StringBuilder errors = new StringBuilder();
                var associado = await _associadoService.RecuperarPorIdAsync(consulta.Associado.Identificador);
                if (associado == null)
                    errors.AppendLine("Associado informado inválido");
                var prestador = await _prestadorService.RecuperarPorIdAsync(consulta.Prestador.Identificador);
                if (prestador == null)
                    errors.AppendLine("Prestador informado inválido");
                var especialidade = await _especialidadeService.RecuperarPorIdAsync(consulta.Especialidade.Identificador);
                if (especialidade == null)
                    errors.AppendLine("Especialidade informado inválido");
                var conveniado = await _conveniadoService.RecuperarPorIdAsync(consulta.Conveniado.Identificador);
                if (conveniado == null)
                    errors.AppendLine("Conveniado informado inválido");

                if(errors.Length > 0)
                {
                    throw new ArgumentException(errors.ToString());
                }
            }
            else
            {
                throw new ArgumentException(validate.ToString());
            }
            consulta.Status = Domain.Enum.Enums.ConsultaStatus.AguardandoAgendamento;
            await _consultarIntegration.AgendarConsulta(consulta);
            return await _consultaRepository.IncluirAsync(consulta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public async Task<Consulta> AtualizarAsync(Consulta consulta)
        {
            return await _consultaRepository.AtualizarAsync(consulta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<Consulta> RecuperarPorIdAsync(long entityId)
        {
            return await _consultaRepository.RecuperarPorIdAsync(entityId);
        }

        public async Task<IEnumerable<Consulta>> RecuperarResumoAsync(long usuarioIdentificador)
        {
            var consultas = await _consultaRepository.RecuperarResumoAsync(usuarioIdentificador);
            if(consultas != null)
            {
                foreach (var item in consultas)
                {
                    item.Fluxo = await _fluxoService.RecuperarPorConsultaAsync(item.Identificador);
                    if(item.Fluxo != null)
                        item.FluxoProcesso = await _consultaFluxoService.RecuperarResumoAsync(item.Identificador);
                }
            }
            return consultas;
        }

        #endregion
    }
}
