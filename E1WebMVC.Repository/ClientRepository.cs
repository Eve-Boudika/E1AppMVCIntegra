using E1WebMVC.Repository.Models;
using E1WebMVC.Repository.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace E1WebMVC.Repository
{
    public class ClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clientes>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetById(int id)
        {
            var client = await _context.Clientes.FindAsync(id);
            return client;
        }

        public async Task<int> Update(Clientes client)
        {
            _context.Update(client);
            var response = await _context.SaveChangesAsync();
            return response;
        }
        public async Task<int> Delete(int id)
        {
            var client = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(client);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(Clientes client)
        {
            _context.Add(client);
            return await _context.SaveChangesAsync();
        }
    }
}

