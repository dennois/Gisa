﻿using Gisa.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Service
{
    public interface IConveniadoService
    {
        public Task<Conveniado> IncluirAsync(Conveniado conveniado);

        public Task<Conveniado> AtualizarAsync(Conveniado conveniado);

        public Task<Conveniado> RecuperarPorIdAsync(long entityId);

        public Task ExcluirAsync(long entityId);

        public Task<IEnumerable<Conveniado>> RecuperarResumo(ConveniadoFiltro filtro);
    }
}
