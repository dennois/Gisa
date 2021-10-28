using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain
{
    public class Consulta : BaseDomain
    {
        public Associado Associado { get; set; }

        public Especialidade Especialidade { get; set; }

        public DateTime Agendamento { get; set; }

        public Conveniado Conveniado { get; set; }

        public Prestador Prestador { get; set; }
    }
}
