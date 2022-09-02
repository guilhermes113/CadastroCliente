using CadastroClientes.Data;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Repository
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;

        }
        public async Task<Cliente> UpdaterCliente(Cliente clienteAlterado)
        {
            _context.Entry(clienteAlterado).State = EntityState.Modified;
            //_context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return clienteAlterado;
        }
        public async Task DeleteCliente(int id )
        {
            var clienteRemovido = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            //_context.Entry(id).State = EntityState.Deleted;
            _context.Clientes.Remove(clienteRemovido);
            await _context.SaveChangesAsync();                                                                                                                                                             
        }
    }
}
