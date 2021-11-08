using Dapper.FluentMap.Dommel.Mapping;
using Gisa.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository.Map
{
    public class ConveniadoMap : DommelEntityMap<Conveniado>
    {
        public ConveniadoMap()
        {
            ToTable("Conveniado");

            Map(x => x.Identificador).ToColumn("Identificador").IsKey().IsIdentity();
        }
    }
}
