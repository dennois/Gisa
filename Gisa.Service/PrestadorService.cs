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
    public class PrestadorService : IPrestadorService
    {
        #region [ Construtor ]

        public PrestadorService(IPrestadorRepository prestadorRepository, IValidator<Prestador> prestadorValidator)
        {
            _prestadorRepository = prestadorRepository;
            _prestadorValidator = prestadorValidator;
        }


        #endregion

        #region [ Membros ]

        readonly IPrestadorRepository _prestadorRepository;
        readonly IValidator<Prestador> _prestadorValidator;

        #endregion

        public Task<Prestador> AtualizarAsync(Prestador prestador)
        {
            throw new NotImplementedException();
        }

        public Task<Prestador> IncluirAsync(Prestador prestador)
        {
            throw new NotImplementedException();
        }

        public Task<Prestador> RecuperarPorIdAsync(long entityId)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
