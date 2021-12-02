﻿using Dapper;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Gisa.SqlRepository
{
    public class ConsultaFluxoRepository : BaseRepository<ConsultaFluxo>, IConsultaFluxoRepository
    {
        public ConsultaFluxoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ConsultaFluxo>> RecuperarResumoAsync(long consultaIdentificador)
        {
            using IDbConnection conn = Connection;
            var sql = @"SELECT 
	*
FROM 
	ConsultaFluxo with(nolock)
WHERE
	Consulta = @Consulta";

            var result = await conn.QueryAsync<ConsultaFluxo>(sql, new { Consulta = consultaIdentificador });
            return result;
        }
    }
}
