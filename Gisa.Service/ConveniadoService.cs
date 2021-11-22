using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.DTO;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class ConveniadoService : IConveniadoService
    {
        #region [ Construtor ]

        public ConveniadoService(IConveniadoRepository conveniadoRepository, IEspecialidadeRepository especialidadeRepository, IValidator<Conveniado> conveniadoValidator)
        {
            _conveniadoRepository = conveniadoRepository;
            _conveniadoValidator = conveniadoValidator;
            _especialidadeRepository = especialidadeRepository;
        }


        #endregion

        #region [ Membros ]

        readonly IConveniadoRepository _conveniadoRepository;
        readonly IValidator<Conveniado> _conveniadoValidator;
        readonly IEspecialidadeRepository _especialidadeRepository;

        #endregion

        public async Task<Conveniado> AtualizarAsync(Conveniado conveniado)
        {
            return await _conveniadoRepository.AtualizarAsync(conveniado);
        }

        public async Task<Conveniado> IncluirAsync(Conveniado conveniado)
        {
            conveniado = await _conveniadoRepository.IncluirAsync(conveniado);
            return conveniado;
        }

        public async Task<Conveniado> RecuperarPorIdAsync(long entityId)
        {
            Conveniado conveniado = await _conveniadoRepository.RecuperarPorIdAsync(entityId);
            conveniado.Especialidades = await _especialidadeRepository.RecuperarPorConveniado(entityId);
            return conveniado;
        }

        public async Task<IEnumerable<Conveniado>> RecuperarResumo(ConveniadoFiltro filtro)
        {
            return await  _conveniadoRepository.RecuperarResumo(filtro);
        }

        public Task ExcluirAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
