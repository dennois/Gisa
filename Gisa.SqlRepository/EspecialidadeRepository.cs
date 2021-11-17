using Dommel;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.SqlRepository.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.SqlRepository
{
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Especialidade>> RecuperarTudo()
        {
            using IDbConnection connection = Connection;

            var especialidadeEntities = await connection.GetAllAsync<Especialidade>();

            return (IEnumerable<Especialidade>)especialidadeEntities;
        }
    }
}
