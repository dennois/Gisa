using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.Domain.Interfaces.Integration
{
    public interface IEspecialidadeIntegration
    {
        public Task IncluirEspecialidade(Especialidade especialidade);
    }
}
