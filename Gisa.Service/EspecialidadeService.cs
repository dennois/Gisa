using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        #region [ Construtor ]

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IValidator<Especialidade> especialidadeValidator)
        {
            _especialidadeRepository = especialidadeRepository;
            _especialidadeValidator = especialidadeValidator;
        }


        #endregion

        #region [ Membros ]

        readonly IEspecialidadeRepository _especialidadeRepository;
        readonly IValidator<Especialidade> _especialidadeValidator;

        #endregion

        public Task<Especialidade> AtualizarAsync(Especialidade especialidade)
        {
            throw new NotImplementedException();
        }

        public Task<Especialidade> IncluirAsync(Especialidade especialidade)
        {
            throw new NotImplementedException();
        }

        public Task<Especialidade> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
