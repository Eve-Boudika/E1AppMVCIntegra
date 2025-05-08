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
    }
}
