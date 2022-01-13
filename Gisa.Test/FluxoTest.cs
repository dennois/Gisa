using FluentValidation;
using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using Gisa.Domain.Validation;
using Gisa.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Test
{
    public class FluxoTest
    {
        #region [ Membros ]

        AbstractValidator<Fluxo> _fluxoValidator;
        IFluxoService  fluxoService;

        #endregion

        [SetUp]
        public void Setup()
        {
            _fluxoValidator = new FluxoValidator();
        }


        [TestCase("123456789", "123465678901234656789012346567890123465678901234656789012346567890",null)]
        [TestCase("123456789", null, "123")]
        [TestCase(null, "123", "123")]
        [TestCase("123456789012345678901234567890123456789012345678901234567890", "123", "123")]
        [TestCase("123", "1234567890X", "123")]
        [Test]
        public void Nao_Deve_IncluirFluxo_com_Dados_invalidos(string nome, string codigo, string processo)
        {
            Fluxo fluxo = new Fluxo();
            fluxo.Nome = nome;
            fluxo.Codigo = codigo;
            fluxo.Processo = processo;

            fluxoService = new FluxoService(null, _fluxoValidator);
            Assert.ThrowsAsync<ArgumentException>(async () => await fluxoService.IncluirAsync(fluxo));
        }

        [TestCase("123", "1234567890", "123")]
        [Test]
        public void Deve_IncluirFluxo_com_Dados_validos(string nome, string codigo, string processo)
        {
            Fluxo fluxo = new Fluxo();
            fluxo.Nome = nome;
            fluxo.Codigo = codigo;
            fluxo.Processo = processo;

            var fluxoRepository = new Mock<IFluxoRepository>();
            fluxoRepository.Setup(m => m.IncluirAsync(It.IsAny<Fluxo>())).ReturnsAsync(() =>
            {
                return new Fluxo() { Identificador = 1 };
            });

            fluxoService = new FluxoService(fluxoRepository.Object, _fluxoValidator);
            var result = fluxoService.IncluirAsync(fluxo).Result;
            Assert.IsNotNull(result);
        }
    }
}
