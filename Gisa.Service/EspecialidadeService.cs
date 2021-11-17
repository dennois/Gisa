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
    public class EspecialidadeService : IEspecialidadeService
    {
        #region [ Construtor ]

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IValidator<Especialidade> especialidadeValidator, IEspecialidadeIntegration especialidadeIntegration)
        {
            _especialidadeRepository = especialidadeRepository;
            _especialidadeValidator = especialidadeValidator;
            _especialidadeIntegration = especialidadeIntegration;
        }


        #endregion

        #region [ Membros ]

        readonly IEspecialidadeRepository _especialidadeRepository;
        readonly IValidator<Especialidade> _especialidadeValidator;
        readonly IEspecialidadeIntegration _especialidadeIntegration;

        #endregion

        public Task<Especialidade> AtualizarAsync(Especialidade especialidade)
        {
            throw new NotImplementedException();
        }

        public async Task<Especialidade> IncluirAsync(Especialidade especialidade)
        {
            await _especialidadeIntegration.IncluirEspecialidade(especialidade);
            return await _especialidadeRepository.IncluirAsync(especialidade);
        }

        public async Task<Especialidade> RecuperarPorIdAsync(long entityId)
        {
            return await _especialidadeRepository.RecuperarPorIdAsync(entityId);
        }

        public async Task<IEnumerable<Especialidade>> RecuperarTudo()
        {
            //List<Especialidade> result = new List<Especialidade>();
            //result.Add(new Especialidade() { Codigo = "qqq" });
            //result.Add(new Especialidade() { Codigo = "222" });
            //return result;
            return await _especialidadeRepository.RecuperarTudo();
        }

        public Task ExcluirAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
