using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository
{
    public class LocalizacaoRepository : BaseRepository<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void AtualizarLocalizacaoConveniado(Localizacao localizacao, long conveniadoIdentificador)
        {
            throw new NotImplementedException();
        }

        public void InserirLocalizacaoConveniado(Localizacao localizacao, long conveniadoIdentificador)
        {
            throw new NotImplementedException();
        }
    }
}
