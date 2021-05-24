using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Usuario.Core;
using Usuario.Domain;
using Xunit;

namespace Test
{
    public class TestesUsuario
    {
        private Mock<UsuarioService> mock;

        public TestesUsuario()
        {
            mock = new Mock<UsuarioService>(MockBehavior.Strict);

            mock.Setup(s => s.ListarTodos())
                .Returns(() => new List<ApplicationUser> { new ApplicationUser { } }.AsEnumerable());

            mock.Setup(s => s.Incluir("user", "123456"))
            .Returns(() => true);

            mock.Setup(s => s.Atualizar("admin-Usuario_test@teste.com.br", "userupdated"))
            .Returns(() => true);

            mock.Setup(s => s.Obter("admin-Usuario_test@teste.com.br"))
           .Returns(() => new ApplicationUser());

            mock.Setup(s => s.Excluir("admin-Usuario_test@teste.com.br"))
            .Returns(() => true);

            mock.Setup(s => s.ChangePassword("admin-Usuario_test@teste.com.br", "123456", "654321"))
            .Returns(() => true);
        }

        [Fact]
        public void TestarListarTodos()
        {
            var ret = mock.Object.ListarTodos();
            ret.Should().NotBeEmpty();
        }

        [Fact]
        public void TestarObter()
        {
            var ret = mock.Object.Obter("admin-Usuario_test@teste.com.br");
            ret.Should().NotBeNull();
        }

        [Fact]
        public void TestarIncluir()
        {
            var ret = mock.Object.Incluir("user", "123456");
            ret.Should().BeTrue();
        }

        [Fact]
        public void TestarAtualizar()
        {
            var ret = mock.Object.Atualizar("admin-Usuario_test@teste.com.br", "userupdated");
            ret.Should().BeTrue();
        }

        [Fact]
        public void TestarExcluir()
        {
            var ret = mock.Object.Excluir("admin-Usuario_test@teste.com.br");
            ret.Should().BeTrue();
        }

        [Fact]
        public void TestarTrocaPwd()
        {
            var ret = mock.Object.ChangePassword("admin-Usuario_test@teste.com.br", "123456", "654321");
            ret.Should().BeTrue();
        }
    }
}