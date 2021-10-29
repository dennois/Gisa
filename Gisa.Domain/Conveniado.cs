using Gisa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain
{
    public class Conveniado : BaseDomain
    {
        public string Nome { get; set; }

        public string Codigo { get; set; }

        public IEnumerable<Especialidade> Especialidades { get; set; }

        public IEnumerable<Prestador> Prestadores { get; set; }

        public Localizacao Endereco { get; set; }

        public Enums.ConveniadoTipo Tipo { get; set; }
    }
}
