using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RinconGuatemaltecoApp.Data;
using RinconGuatemaltecoApp.Models;

namespace RinconGuatemaltecoApp.Controllers
{
    public class DespachosController : Controller
    {
        private readonly RinconGuatemaltecoContext _context;

        public DespachosController(RinconGuatemaltecoContext context)
        {
            _context = context;
        }

        // GET: Despachos
        public async Task<IActionResult> Index()
        {
            var rinconGuatemaltecoContext = _context.Despachos.Include(d => d.Cliente);
            return View(await rinconGuatemaltecoContext.ToListAsync());
        }

        // GET: Despachos/Create
        public IActionResult Create()
        {
            // Llenar ViewBag.Clientes con datos concatenados de Nombre y Apellido
            ViewBag.Clientes = new SelectList(
                _context.Clientes.Select(c => new { c.ClienteID, NombreCompleto = c.Nombre + " " + c.Apellido }),
                "ClienteID",
                "NombreCompleto"
            );
            return View();
        }

        // POST: Despachos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespachoID,ClienteID,Fecha,Total")] Despacho despacho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despacho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "Nombre", despacho.ClienteID);
            return View(despacho);
        }

        // GET: Despachos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho == null)
            {
                return NotFound();
            }

            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "Nombre", despacho.ClienteID);
            return View(despacho);
        }

        // POST: Despachos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespachoID,ClienteID,Fecha,Total")] Despacho despacho)
        {
            if (id != despacho.DespachoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despacho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespachoExists(despacho.DespachoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "Nombre", despacho.ClienteID);
            return View(despacho);
        }

        // GET: Despachos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DespachoID == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // POST: Despachos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho != null)
            {
                _context.Despachos.Remove(despacho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespachoExists(int id)
        {
            return _context.Despachos.Any(e => e.DespachoID == id);
        }
    }
}
