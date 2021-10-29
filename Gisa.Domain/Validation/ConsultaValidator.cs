using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain.Validation
{
    public class ConsultaValidator : BaseValidator<Consulta>
    {
        #region [ Constructor ]

        public ConsultaValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Associado).Must(ValidarNull).WithMessage("Associado não informado");
            RuleFor(x => x.Associado.Identificador).GreaterThan(0);
            RuleFor(x => x.Especialidade).Must(ValidarNull).WithMessage("Especialidade não informada");
            RuleFor(x => x.Especialidade.Identificador).GreaterThan(0);
            RuleFor(x => x.Conveniado).Must(ValidarNull).WithMessage("Conveniado não informado");
            RuleFor(x => x.Conveniado.Identificador).GreaterThan(0);
            RuleFor(x => x.Prestador).Must(ValidarNull).WithMessage("Prestador não informado");
            RuleFor(x => x.Prestador.Identificador).GreaterThan(0);
            RuleFor(x => x.Agendamento).GreaterThan(DateTime.UtcNow.AddMinutes(30));
            RuleFor(x => x.Status).Must(x => x != 0);
            RuleFor(x => x.Anamnese).NotNull().NotEmpty();
            RuleFor(x => x.PrescricaoMedica).NotNull().NotEmpty();
        }

        #endregion

        private bool ValidarNull(BaseDomain model)
        {
            return model != null;
        }
    }
}
