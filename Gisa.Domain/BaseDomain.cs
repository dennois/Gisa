using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain
{
    public abstract class BaseDomain
    {
        public long Identificador { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
