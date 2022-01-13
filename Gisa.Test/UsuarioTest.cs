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
    public class UsuarioTest
    {
        #region [ Membros ]

        AbstractValidator<Usuario> _usuarioValidator;
        IUsuarioService usuarioService;

        #endregion

        [SetUp]
        public void Setup()
        {
            _usuarioValidator = new UsuarioValidator();
        }

        [TestCase("", "login","senha","perfil")]
        [TestCase("nome", "", "senha", "perfil")]
        [TestCase("nome", "login", "", "perfil")]
        [TestCase("nome", "login", "senha", "")]

        [TestCase("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890X", "login", "senha", "perfil")]
        [TestCase("nome", "12345678901234567890123456789012345678901234567890X", "senha", "perfil")]
        [TestCase("nome", "login", "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890X", "perfil")]
        [TestCase("nome", "login", "senha", "12345678901234567890123456789012345678901234567890X")]
        [Test]
        public void Nao_Deve_Incluir_Usuario_com_Dados_invalidos(string nome, string login, string senha, string perfil)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            usuario.Perfil = perfil;

            usuarioService = new UsuarioService(null,null, _usuarioValidator);
            Assert.ThrowsAsync<ArgumentException>(async () => await usuarioService.IncluirAsync(usuario));
        }

        [TestCase("nome", "login", "senha", "perfil")]
        [Test]
        public void Deve_Incluir_Usuario_com_Dados_validos(string nome, string login, string senha, string perfil)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            usuario.Perfil = perfil;

            var usuarioRepository = new Mock<IUsuarioRepository>();
            usuarioRepository.Setup(m => m.IncluirAsync(It.IsAny<Usuario>())).ReturnsAsync(() =>
            {
                return new Usuario() { Identificador = 1 };
            });

            usuarioService = new UsuarioService(usuarioRepository.Object, null, _usuarioValidator);
            var result = usuarioService.IncluirAsync(usuario).Result;
            Assert.IsNotNull(result);
        }

        [TestCase("", "login", "senha", "perfil")]
        [TestCase("nome", "", "senha", "perfil")]
        [TestCase("nome", "login", "", "perfil")]
        [TestCase("nome", "login", "senha", "")]

        [TestCase("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890X", "login", "senha", "perfil")]
        [TestCase("nome", "12345678901234567890123456789012345678901234567890X", "senha", "perfil")]
        [TestCase("nome", "login", "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890X", "perfil")]
        [TestCase("nome", "login", "senha", "12345678901234567890123456789012345678901234567890X")]
        [Test]
        public void Nao_Deve_Alterar_Usuario_com_Dados_invalidos(string nome, string login, string senha, string perfil)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            usuario.Perfil = perfil;

            usuarioService = new UsuarioService(null, null, _usuarioValidator);
            Assert.ThrowsAsync<ArgumentException>(async () => await usuarioService.AtualizarAsync(usuario));
        }

        [TestCase("nome", "login", "senha", "perfil")]
        [Test]
        public void Deve_Alterar_Usuario_com_Dados_validos(string nome, string login, string senha, string perfil)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            usuario.Perfil = perfil;

            var usuarioRepository = new Mock<IUsuarioRepository>();
            usuarioRepository.Setup(m => m.AtualizarAsync(It.IsAny<Usuario>())).ReturnsAsync(() =>
            {
                return new Usuario() { Identificador = 1 };
            });

            usuarioService = new UsuarioService(usuarioRepository.Object, null, _usuarioValidator);
            var result = usuarioService.AtualizarAsync(usuario).Result;
            Assert.IsNotNull(result);
        }
    }
}
