using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;

namespace Proyecto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _db;


        public ProductoController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var Productos = _db.Productos.Include(c => c.Categoria).Include(s => s.Rubro);
            return View(await Productos.ToListAsync());
        }
        public IActionResult Create()
        {   
            ViewData["Categoria"] = new SelectList(_db.Categorias, "Id", "Descripcion");
            ViewData["Rubro"] = new SelectList(_db.Rubros, "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoViewModel model)        
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto()
                {
                    Descripcion = model.Descripcion,
                    Precio = model.Precio,
                    CategoriaId = model.CategoriaId,
                    RubroId = model.RubroId
                };
                _db.Add(producto);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View("Create");
        }
       

        public async Task<IActionResult> Editar(int id)
        {
            // Buscar el producto por ID en la base de datos
            var producto = await _db.Productos.FindAsync(id);

            // Verificar si el producto no existe
            if (producto == null)
            {
                return NotFound();
            }

            // Mapear el producto a ProductoViewModel (si es necesario)
            var productoViewModel = new ProductoViewModel
            {
                Id = producto.Id,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio
            };

            // Poblar la lista de categorías en ViewBag (asegúrate de tener esta lógica en tu controlador)
            ViewData["Categoria"] = new SelectList(_db.Categorias, "Id", "Descripcion");


            // Pasar el ProductoViewModel a la vista
            return View(productoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto()
                {
                    Id=model.Id,
                    Descripcion = model.Descripcion,
                    Precio = model.Precio,
                    CategoriaId = model.CategoriaId
                };
                _db.Update(producto);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Categoria"] = new SelectList(_db.Categorias, "idCategoria", "Descripcion", model.CategoriaId);
            var Productos = _db.Productos.Include(c => c.Categoria).Include(s => s.Rubro);
            return View(model);
        }
    }
}