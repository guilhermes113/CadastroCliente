using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repository;
using CadastroClientes.Contracts;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.GetClientes());
        }
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            

            return await _clienteRepository.GetClienteById(id); ;
        }
        //
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            //if (id != cliente.Id)
            //{
            //    return BadRequest();
            //}
            return Ok(await _clienteRepository.UpdaterCliente(cliente));
        }
        //
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var NovoCliente = await _clienteRepository.AddCliente(cliente);

            return CreatedAtAction("GetCliente", new { id = NovoCliente.Id }, NovoCliente);
        }
        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteRepository.DeleteCliente(id);

            return NoContent();
        }
        
    }
}
