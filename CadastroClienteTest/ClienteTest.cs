using CadastroClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroClienteTest
{
    public class ClienteTest
    {
        [Fact]
        public void Idade_VinteAnosDepois_RetornaVinte()
        {
            Cliente cliente = new Cliente("José da Silva", DateTime.Now.AddYears(-20),"jsilva@mail.com");
            var idade = cliente.Idade();
            Assert.Equal(20, idade);
        }
        [Fact]
        public void Idade_VinteAnosDepoisEUmDiaDepois_RetornaVinte()
        {
            Cliente cliente = new Cliente("José da Silva", DateTime.Now.AddYears(-20).AddDays(-1), "jsilva@mail.com");
            var idade = cliente.Idade();
            Assert.Equal(20, idade);
        }
        [Fact]
        public void Idade_VinteAnosDepoisEUmDiaAntes_RetornaVinte()
        {
            Cliente cliente = new Cliente("Jose da Silva", DateTime.Now.AddYears(-20).AddDays(1), "jsilva@mail.com");
            var idade = cliente.Idade();
            Assert.Equal(19, idade);
        }
        [Theory]
        [InlineData("Joao","2010,05,14","joao@gmail.com")]
        public void AtualizarDados_AlteraNomeIdadeEmail_RetornaAlterado(string nome,DateTime nascimento,string email)
        {

            Cliente cliente = new Cliente("Jose Silva", new DateTime(2006, 12, 06), "josedaSilva@gmail.com");
            cliente.AtualizarDados(nome, nascimento, email);
            Assert.Equal(cliente.Nome, nome);
            Assert.Equal(cliente.Nascimento ,nascimento);
            Assert.Equal(cliente.Email, email);

        }
    }
}
