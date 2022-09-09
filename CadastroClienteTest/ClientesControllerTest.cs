using CadastroClientes.Contracts;
using CadastroClientes.Controllers;
using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CadastroClienteTest
{
    public class ClientesControllerTest
    {
        Mock <IClienteRepository> _repository;

        public ClientesControllerTest()
        {
            _repository = new Mock<IClienteRepository>();
        }

        [Fact]
        public async void GetClientes_ExecutaAcao_RetornaOkAction()
        {
            ClientesController controller = new ClientesController(_repository.Object);
            var result = await controller.GetClientes();
            Assert.IsType<OkObjectResult>(result.Result);;
        }
        [Fact]
        public async void GetCliente_ExecutaAcao_RetornaArrayClientes()
        {
            ClientesController controller = new ClientesController(_repository.Object);
            var clientes = new List<Cliente>()
            {
                new Cliente("x",DateTime.Now,"mail"),
                new Cliente("Y",DateTime.Now,"mail2")
            };
            _repository.Setup(repo => repo.GetClientes()).Returns(Task.FromResult(clientes));
            var consulta = await controller.GetClientes();
            var lista = Assert.IsType<List<Cliente>>((consulta.Result as OkObjectResult).Value);
            Assert.Equal(2,lista.Count);
        }
        [Fact]
        public async void GetCliente_ExecutaAcao_RetornaCliente()
        {
            ClientesController controller = new ClientesController(_repository.Object);
            var cliente = new Cliente("x", DateTime.Now, "mail");
            _repository.Setup(repo => repo.GetClienteById(1)).Returns(Task.FromResult(cliente));
            var consulta = await controller.GetCliente(1);
            Assert.IsType<List<Cliente>>((consulta.Result as OkObjectResult).Value);
            //Assert.Equal(2, lista.Count);


        }
    }
}
