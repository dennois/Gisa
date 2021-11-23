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

        public ConveniadoService(IConveniadoRepository conveniadoRepository, IEspecialidadeRepository especialidadeRepository, ILocalizacaoRepository localizacaoRepository, IValidator<Conveniado> conveniadoValidator)
        {
            _conveniadoRepository = conveniadoRepository;
            _conveniadoValidator = conveniadoValidator;
            _especialidadeRepository = especialidadeRepository;
            _localizacaoRepository = localizacaoRepository;
        }

        #endregion

        #region [ Membros ]

        readonly IConveniadoRepository _conveniadoRepository;
        readonly IValidator<Conveniado> _conveniadoValidator;
        readonly IEspecialidadeRepository _especialidadeRepository;
        readonly ILocalizacaoRepository _localizacaoRepository;

        #endregion

        public async Task<Conveniado> AtualizarAsync(Conveniado conveniado)
        {
            conveniado = await _conveniadoRepository.AtualizarAsync(conveniado);
            _especialidadeRepository.ExcluirEspecialidadeConveniado(conveniado.Identificador);
            foreach (var item in conveniado.Especialidades)
            {
                _especialidadeRepository.InserirEspecialidadeConveniado(item, conveniado.Identificador);
            }
            await _localizacaoRepository.AtualizarAsync(conveniado.Endereco);
            return conveniado;
        }

        public async Task<Conveniado> IncluirAsync(Conveniado conveniado)
        {
            var endereco = await _localizacaoRepository.IncluirAsync(conveniado.Endereco);
            conveniado.Endereco = endereco;
            conveniado = await _conveniadoRepository.IncluirAsync(conveniado);
            return conveniado;
        }

        public async Task<Conveniado> RecuperarPorIdAsync(long entityId)
        {
            Conveniado conveniado = await _conveniadoRepository.RecuperarPorIdAsync(entityId);
            conveniado.Especialidades = await _especialidadeRepository.RecuperarPorConveniado(entityId);
            conveniado.Endereco = await _localizacaoRepository.RecuperarPorIdAsync(conveniado.Endereco.Identificador);
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
