using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RinconGuatemaltecoApp.Data;
using RinconGuatemaltecoApp.Models;
using System.Threading.Tasks;

namespace RinconGuatemaltecoApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly RinconGuatemaltecoContext _context;

        public ClientesController(RinconGuatemaltecoContext context)
        {
            _context = context;
        }

        // Acción para listar todos los clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes); // Asegúrate de que 'clientes' se está pasando correctamente
        }

        // Método GET para mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Método POST para procesar el formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.FechaRegistro = DateTime.Now; // Asigna la fecha actual
                _context.Clientes.Add(cliente); // Agrega el cliente al contexto
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                TempData["SuccessMessage"] = "Cliente agregado exitosamente."; // Mensaje de confirmación
                return RedirectToAction(nameof(Index)); // Redirige a la lista de clientes
            }
            return View(cliente); // Si el modelo no es válido, regresa a la vista con errores de validación
        }



        // Acción para mostrar el formulario de edición
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // Acción para actualizar un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(cliente);
        }

        // Acción para mostrar el formulario de confirmación de eliminación
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Acción para eliminar un cliente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteID == id);
        }
    }
}
