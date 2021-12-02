﻿using Dapper;
using Dommel;
using Gisa.Domain;
using Gisa.Domain.DTO;
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
    public class ConveniadoRepository : BaseRepository<Conveniado>, IConveniadoRepository
    {
        public ConveniadoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IList<Conveniado>> RecuperarResumo(ConveniadoFiltro filtro)
        {
            using IDbConnection conn = Connection;
            var sql = @"SELECT distinct
	                        con.*
                        FROM
	                        conveniado as con inner join
	                        ConveniadoEspecialidade as ces on con.identificador = ces.conveniado inner join
	                        localizacao as loc on con.endereco = loc.identificador
                        where
	                        (Nome LIKE '%' + @Nome + '%' or @Nome is null) 
                        AND (Tipo = @Tipo OR @Tipo = '\0' or @Tipo is null)
                        and (ces.especialidade = @especialidade or @especialidade is null) 
                        and (loc.estado = @estado or @estado is null)
                        and (loc.cidade = @cidade or @cidade is null)";

            var result = await conn.QueryAsync<ConveniadoEntity>(sql, new { Nome = String.IsNullOrEmpty(filtro.Nome) ? string.Empty : filtro.Nome, Tipo = ((char)filtro.ConveniadoTipo).ToString(), estado = filtro.Estado, cidade = filtro.Cidade, especialidade = filtro.Especialidade });
            return result.Cast<Conveniado>().ToList();
        }

        public override async Task<Conveniado> RecuperarPorIdAsync(long entityId)
        {
            Conveniado conveniado = null;
            using IDbConnection conn = Connection;
            var entity = await conn.GetAsync<ConveniadoEntity>(entityId);
            if (entity != null)
            {
                conveniado = (Conveniado)entity;
                conveniado.Endereco = new Localizacao();
                conveniado.Endereco.Identificador = entity.EnderecoId;
            }
            return conveniado;
        }

        public override async Task<Conveniado> AtualizarAsync(Conveniado entity)
        {
            using IDbConnection conn = Connection;
            entity.DataAlteracao = DateTime.UtcNow;
            ConveniadoEntity conveniadoEntity = new ConveniadoEntity(entity);
            conveniadoEntity.EnderecoId = 2;
            await conn.UpdateAsync<ConveniadoEntity>(conveniadoEntity);
            return entity;
        }
    }
}
