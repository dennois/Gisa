﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Repository
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        public Task<IEnumerable<Especialidade>> RecuperarTudo();

        public Task<IEnumerable<Especialidade>> RecuperarPorConveniado(long conveniadoIdentificador);

        public void InserirEspecialidadeConveniado(IEnumerable<Especialidade> especialidades, long conveniadoIdentificador);

        public void ExcluirEspecialidadeConveniado(long conveniadoIdentificador);
    }
}
