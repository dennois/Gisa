using Dapper;
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
            var sql = "SELECT * FROM Conveniado AS C (NOLOCK) WHERE Nome LIKE '%' + @Nome + '%' AND (Tipo = @Tipo OR @Tipo = '\0')";

            var result = await conn.QueryAsync<ConveniadoEntity>(sql, new { Nome = String.IsNullOrEmpty(filtro.Nome) ? string.Empty : filtro.Nome, Tipo = ((char)filtro.ConveniadoTipo).ToString() });
            return result.Cast<Conveniado>().ToList();
        }

        public override async Task<Conveniado> RecuperarPorIdAsync(long entityId)
        {
            using IDbConnection conn = Connection;
            var entity = await conn.GetAsync<ConveniadoEntity>(entityId);
            if (entity != null)
                return (Conveniado)entity;
            else
                return null;
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
