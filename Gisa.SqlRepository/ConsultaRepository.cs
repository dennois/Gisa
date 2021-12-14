﻿using Dapper;
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
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Consulta>> RecuperarResumoAsync(long usuarioIdentificador)
        {
            using IDbConnection conn = Connection;
            var sql = @"SELECT
    CONS.IDENTIFICADOR,
	CONS.AGENDAMENTO,
	CONS.ANAMNESE,
	CONS.PRESCRICAOMEDICA,
	CONS.STATUS as StatusString,
	ESP.NOME AS ESPECIALIDADENOME,
	CONV.NOME AS CONVENIADONOME,
	PRE.NOME AS PrestadorNOME,
	CONV.IDENTIFICADOR as CONVENIADOIDENTIFICADOR,
	Logradouro,
    Bairro,
    Cidade,
    Estado,
    Complemento,
    Numero,
    CEP,
    Latitude,
    Longitude
FROM
	CONSULTA AS CONS WITH(NOLOCK) INNER JOIN
	ESPECIALIDADE AS ESP WITH(NOLOCK) ON CONS.ESPECIALIDADE = ESP.IDENTIFICADOR INNER JOIN
	CONVENIADO AS CONV WITH(NOLOCK) ON CONS.CONVENIADO = CONV.IDENTIFICADOR LEFT JOIN
	PRESTADOR AS PRE WITH(NOLOCK) ON  CONS.Prestador = PRE.IDENTIFICADOR INNER JOIN
	ASSOCIADO AS ASS WITH(NOLOCK) ON CONS.ASSOCIADO = ASS.IDENTIFICADOR INNER JOIN
	Localizacao as loc with(nolock) on CONV.endereco = loc.identificador
WHERE
	ASS.Usuario = @Usuario
ORDER BY
	AGENDAMENTO";

            var result = await conn.QueryAsync<ConsultaEntity>(sql, new { Usuario = usuarioIdentificador });
            return result;//.Cast<Conveniado>().ToList();
        }

        public override async Task<Consulta> IncluirAsync(Consulta entity)
        {
            using IDbConnection conn = Connection;
            entity.DataAlteracao = DateTime.UtcNow;
            string sql = @"INSERT INTO [dbo].[Consulta]
           (Associado
           ,Especialidade
           ,Conveniado
           ,Prestador
            ,Agendamento
            ,Status
            ,Fluxo
           ,DataInclusao)
     VALUES
 (@Associado
           ,@Especialidade
           ,@Conveniado
           ,@Prestador
            ,@Agendamento
            ,@Status
            ,@Fluxo
           ,getutcdate())

select @@identity";

            var result = await conn.ExecuteScalarAsync<long>(sql, new { Associado = entity.Associado.Identificador, Especialidade = entity.Especialidade.Identificador,
                Conveniado = entity.Conveniado.Identificador, Prestador = entity.Prestador.Identificador , Agendamento = entity.Agendamento,
                Status = (char)entity.Status, Fluxo = entity.Fluxo.Identificador
            });
            entity.Identificador = Convert.ToInt64(result);
            return entity;
        }
    }
}
