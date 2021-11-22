using Dapper;
using Dommel;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.SqlRepository.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.SqlRepository
{
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void ExcluirEspecialidadeConveniado(long conveniadoIdentificador)
        {
            throw new NotImplementedException();
        }

        public void InserirEspecialidadeConveniado(IEnumerable<Especialidade> especialidades, long conveniadoIdentificador)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Especialidade>> RecuperarPorConveniado(long conveniadoIdentificador)
        {
            using IDbConnection conn = Connection;
            var sql = @"SELECT
	                        E.*
                        FROM
	                        CONVENIADO AS C INNER JOIN
	                        CONVENIADOESPECIALIDADE AS CE ON C.IDENTIFICADOR = CE.CONVENIADO INNER JOIN
	                        ESPECIALIDADE AS E ON E.IDENTIFICADOR = CE.ESPECIALIDADE
                        WHERE
	                        C.IDENTIFICADOR = @IDENTIFICADOR
                        ORDER BY
	                        E.NOME";

            var result = await conn.QueryAsync<Especialidade>(sql, new { IDENTIFICADOR = conveniadoIdentificador });
            return result.ToList();
        }

        public async Task<IEnumerable<Especialidade>> RecuperarTudo()
        {
            using IDbConnection connection = Connection;

            var especialidadeEntities = await connection.GetAllAsync<Especialidade>();

            return (IEnumerable<Especialidade>)especialidadeEntities;
        }
    }
}
