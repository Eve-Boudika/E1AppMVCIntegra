using E1WebMVC.Repository.Models;
using E1WebMVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace E1WebMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClientService _clientService;

        public ClienteController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clientDto = await _clientService.Get();
            return View(clientDto);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cuit,RazonSocial,Telefono,Direccion,Activo")] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                var response = await _clientService.Create(cliente);

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var clientDto = await _clientService.GetById(id);

            return View(clientDto);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cuit,RazonSocial,Telefono,Direccion,Activo")] Clientes client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            var clientDto = await _clientService.Update(client);

            return View(clientDto);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var clientDto = await _clientService.GetById(id);
 
            return View(clientDto);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _clientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
