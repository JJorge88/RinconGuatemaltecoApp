using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RinconGuatemaltecoApp.Data;
using RinconGuatemaltecoApp.Models;

namespace RinconGuatemaltecoApp.Controllers
{
    public class DetalleDespachosController : Controller
    {
        private readonly RinconGuatemaltecoContext _context;

        public DetalleDespachosController(RinconGuatemaltecoContext context)
        {
            _context = context;
        }

        // GET: DetalleDespachos/Create
        public IActionResult Create(int despachoId)
        {
            ViewBag.Productos = new SelectList(_context.Productos, "ProductoID", "Nombre");
            ViewBag.DespachoID = despachoId;
            return View();
        }

        // POST: DetalleDespachos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespachoID,ProductoID,Cantidad")] DetalleDespacho detalleDespacho)
        {
            if (ModelState.IsValid)
            {
                var producto = await _context.Productos.FindAsync(detalleDespacho.ProductoID);
                if (producto != null)
                {
                    detalleDespacho.Subtotal = producto.Precio * detalleDespacho.Cantidad;
                    _context.Add(detalleDespacho);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Despachos", new { id = detalleDespacho.DespachoID });
                }
            }

            ViewBag.Productos = new SelectList(_context.Productos, "ProductoID", "Nombre", detalleDespacho.ProductoID);
            ViewBag.DespachoID = detalleDespacho.DespachoID;
            return View(detalleDespacho);
        }

        // GET: DetalleDespachos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleDespacho = await _context.DetalleDespachos
                .Include(d => d.Producto)
                .Include(d => d.Despacho)
                .FirstOrDefaultAsync(m => m.DetalleID == id);

            if (detalleDespacho == null)
            {
                return NotFound();
            }

            return View(detalleDespacho);
        }

        // POST: DetalleDespachos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleDespacho = await _context.DetalleDespachos.FindAsync(id);
            if (detalleDespacho != null)
            {
                _context.DetalleDespachos.Remove(detalleDespacho);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Despachos", new { id = detalleDespacho.DespachoID });
        }
    }
}
