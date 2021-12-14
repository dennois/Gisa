using Dapper.FluentMap.Dommel.Mapping;
using Gisa.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository.Map
{
    public class AssociadoMap : DommelEntityMap<Associado>
    {
        public AssociadoMap()
        {
            ToTable("Associado");

            Map(x => x.Identificador).ToColumn("Identificador").IsKey().IsIdentity();
            Map(x => x.Status).Ignore();
            Map(x => x.Endereco).Ignore();
        }
    }
}
