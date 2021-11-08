using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Enum;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using Gisa.Domain.Validation;
using Gisa.Service;
using Moq;
using NUnit.Framework;
using System;

namespace Gisa.Test
{
    public class ConsultaTest
    {
        #region [ Membros ]

        AbstractValidator<Consulta> _consultaValidator;
        IConsultaService consultaService;

        #endregion

        [SetUp]
        public void Setup()
        {
            _consultaValidator = new ConsultaValidator();
        }

        [TestCase(null, null, null, null, null, null, null, null)]
        [TestCase(0, 1, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(999, 1, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, null, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 0, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 999, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, null, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 0, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 999, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, null, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 0, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 999, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 1, "2000-01-01", "anamnese", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 1, "2100-01-01", null, "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 1, "2100-01-01", "", "prescricaoMedica", 'A')]
        [TestCase(1, 1, 1, 1, "2100-01-01", "anamnese", null, 'A')]
        [TestCase(1, 1, 1, 1, "2100-01-01", "anamnese", "", 'A')]
        [TestCase(1, 1, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", null)]
        [Test]
        public void Nao_Deve_Agendar_Consulta_com_Dados_invalidos(long? idAssociado, long? iEspecialidade, long? iConveniado, long? iPrestador, DateTime agendamento, string anamnese, string prescricaoMedica, Enums.ConsultaStatus status)
        {
            Associado associado = null;
            if (idAssociado.HasValue)
                associado = new Associado() { Identificador = idAssociado.Value };

            Especialidade especialidade = null;
            if (iEspecialidade.HasValue)
                especialidade = new Especialidade() { Identificador = iEspecialidade.Value };

            Conveniado conveniado = null;
            if (iConveniado.HasValue)
                conveniado = new Conveniado() { Identificador = iConveniado.Value };

            Prestador prestador = null;
            if (iPrestador.HasValue)
                prestador = new Prestador() { Identificador = iPrestador.Value };

            var  associadoService = new Mock<IAssociadoService>();
            associadoService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            associadoService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Associado();
            });

            var especialidadeService = new Mock<IEspecialidadeService>();
            especialidadeService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            especialidadeService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Especialidade();
            });

            var conveniadoService = new Mock<IConveniadoService>();
            conveniadoService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            conveniadoService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Conveniado();
            });

            var prestadorService = new Mock<IPrestadorService>();
            prestadorService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            prestadorService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Prestador();
            });


            Consulta consulta = new Consulta(associado, especialidade, conveniado, prestador, agendamento, anamnese, prescricaoMedica, status);
            consultaService = new ConsultaService(null, _consultaValidator, associadoService.Object, especialidadeService.Object, conveniadoService.Object, prestadorService.Object, null);
            Assert.ThrowsAsync<ArgumentException>(async () => await consultaService.AgendarAsync(consulta));
        }

        [TestCase(1, 1, 1, 1, "2100-01-01", "anamnese", "prescricaoMedica", 'A')]
        public void Deve_Agendar_Consulta_com_Dados_validos(long? idAssociado, long? iEspecialidade, long? iConveniado, long? iPrestador, DateTime agendamento, string anamnese, string prescricaoMedica, Enums.ConsultaStatus status)
        {
            Associado associado = null;
            if (idAssociado.HasValue)
                associado = new Associado() { Identificador = idAssociado.Value };

            Especialidade especialidade = null;
            if (iEspecialidade.HasValue)
                especialidade = new Especialidade() { Identificador = iEspecialidade.Value };

            Conveniado conveniado = null;
            if (iConveniado.HasValue)
                conveniado = new Conveniado() { Identificador = iConveniado.Value };

            Prestador prestador = null;
            if (iPrestador.HasValue)
                prestador = new Prestador() { Identificador = iPrestador.Value };

            var associadoService = new Mock<IAssociadoService>();
            associadoService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            associadoService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Associado();
            });

            var especialidadeService = new Mock<IEspecialidadeService>();
            especialidadeService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            especialidadeService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Especialidade();
            });

            var conveniadoService = new Mock<IConveniadoService>();
            conveniadoService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            conveniadoService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Conveniado();
            });

            var prestadorService = new Mock<IPrestadorService>();
            prestadorService.Setup(m => m.RecuperarPorIdAsync(999)).ReturnsAsync(() =>
            {
                return null;
            });
            prestadorService.Setup(m => m.RecuperarPorIdAsync(1)).ReturnsAsync(() =>
            {
                return new Prestador();
            });

            var consultaRepository = new Mock<IConsultaRepository>();
            consultaRepository.Setup(m => m.IncluirAsync(It.IsAny<Consulta>())).ReturnsAsync(() =>
            {
                return new Consulta() { Identificador = 1};
            });


            Consulta consulta = new Consulta(associado, especialidade, conveniado, prestador, agendamento, anamnese, prescricaoMedica, status);
            consultaService = new ConsultaService(consultaRepository.Object, _consultaValidator, associadoService.Object, especialidadeService.Object, conveniadoService.Object, prestadorService.Object, null);
            consulta = consultaService.AgendarAsync(consulta).Result;

            Assert.Greater(consulta.Identificador, 0);
        }
    }
}