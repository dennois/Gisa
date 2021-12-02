using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain
{
    public class ConsultaFluxo : BaseDomain
    {
        public string Status { get; set; }

        public string Passo { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
    }
}
