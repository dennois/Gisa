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

        public ConveniadoService(IConveniadoRepository conveniadoRepository, IValidator<Conveniado> conveniadoValidator)
        {
            _conveniadoRepository = conveniadoRepository;
            _conveniadoValidator = conveniadoValidator;
        }


        #endregion

        #region [ Membros ]

        readonly IConveniadoRepository _conveniadoRepository;
        readonly IValidator<Conveniado> _conveniadoValidator;

        #endregion

        public Task<Conveniado> AtualizarAsync(Conveniado conveniado)
        {
            throw new NotImplementedException();
        }

        public Task<Conveniado> IncluirAsync(Conveniado conveniado)
        {
            throw new NotImplementedException();
        }

        public Task<Conveniado> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
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
