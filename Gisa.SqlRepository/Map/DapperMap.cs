using Dapper.Contrib.Extensions;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository.Map
{
    public static class DapperMap
    {
        public static void RegisterDapperMapper()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ConveniadoMap());
                config.AddMap(new EspecialidadeMap());
                config.AddMap(new LocalizacaoMap());
                config.AddMap(new FluxoMap());

                config.ForDommel();
            });

            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                // do something here to pluralize the name of the type
                return type.Name;
            };
        }

    }
}
