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
    public class AssociadoService : IAssociadoService
    {
        #region [ Construtor ]

        public AssociadoService(IAssociadoRepository associadoRepository, IValidator<Associado> associadoValidator)
        {
            _associadoRepository = associadoRepository;
            _associadoValidator = associadoValidator;
        }


        #endregion

        #region [ Membros ]

        readonly IAssociadoRepository _associadoRepository;
        readonly IValidator<Associado> _associadoValidator;

        #endregion

        public Task<Associado> AtualizarAsync(Associado conveniado)
        {
            throw new NotImplementedException();
        }

        public Task<Associado> IncluirAsync(Associado conveniado)
        {
            throw new NotImplementedException();
        }

        public Task<Associado> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
