using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain.Interfaces.Repository
{
    public interface ILocalizacaoRepository : IRepository<Localizacao>
    {
        public void InserirLocalizacaoConveniado(Localizacao localizacao, long conveniadoIdentificador);

        public void AtualizarLocalizacaoConveniado(Localizacao localizacao, long conveniadoIdentificador);
    }
}
