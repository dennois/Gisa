using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
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
            IPrestadorService prestadorService)
        {
            _consultaRepository = consultaRepository;
            _consultaValidator = consultaValidator;
            _associadoService = associadoService;
             _especialidadeService = especialidadeService;
            _conveniadoService = conveniadoService;
            _prestadorService = prestadorService;
        }

        #endregion

        #region [ Membros ]

        readonly IConsultaRepository _consultaRepository;
        readonly IValidator<Consulta> _consultaValidator;
        readonly IAssociadoService _associadoService;
        readonly IEspecialidadeService _especialidadeService;
        readonly IConveniadoService _conveniadoService;
        readonly IPrestadorService _prestadorService;

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

        #endregion
    }
}
