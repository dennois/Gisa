using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain
{
    public class Carteirinha : BaseDomain
    {
        public DateTime Validade { get; set; }

        public string Codigo { get; set; }

        public Empresa? Empresa { get; set; }

        public Plano PlanoContratado { get; set; }

        public bool OpcaoOdontologico { get; set; }

        public Associado Associado { get; set; }
    }
}
