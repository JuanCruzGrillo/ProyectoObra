using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;
using System.Security.AccessControl;

namespace ProyectoObra.Web.Controllers
{
    public class ContratacionProductoController : Controller
    {
        private readonly ContratacionProductoService _contratacionproductoService;
        private readonly ContratacionService _contratacionService;
        private readonly ProductoService _productoService;


        public ContratacionProductoController(ContratacionProductoService contratacionproductoService, ContratacionService contratacionService, ProductoService productoService)
        {
            _contratacionproductoService = contratacionproductoService;
            _contratacionService = contratacionService;
            _productoService = productoService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        { 
            var _contratacion = _contratacionService.ObtenerContratacionesActivas();
            return View(_contratacion);
        }

        public IActionResult Indexina()
        {
            var _contratacion = _contratacionService.ObtenerContratacionesFinalizadas();
            return View(_contratacion);
        }

        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(ContratacionProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contratacionproductoService.CrearContratacionProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");

            }
            return View("Create");
        }
        public IActionResult Create(int id)
        {
            Contratacion? contratacion = _contratacionService.TraerContratacion(id);
            var contratacionProducto = new ContratacionProducto();
            contratacionProducto.Contratacion = contratacion;
            ViewData["Producto"] = new SelectList(_productoService.ObtenerProductos(), "Id", "Descripcion");

            return View(CambiarClaseaModel(contratacionProducto));

        }

        //Procedimiento para guardar el registro en la DB

        public IActionResult Details(int id)
        {
            var contratacionproducto = _contratacionproductoService.TraerContratacionProducto(id);
            if (contratacionproducto == null)
            {
                return NotFound();
            }
            ViewData["Contratacion"] = new SelectList(_contratacionService.ObtenerContrataciones(), "Id", "Descripcion");

            ViewData["Producto"] = new SelectList(_productoService.ObtenerProductos(), "Id", "Descripcion");

            return View((contratacionproducto));
        }
      
        [HttpPost]
        public IActionResult Update(ContratacionProductoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _contratacionproductoService.ActualizarContratacionProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(ContratacionProductoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _contratacionproductoService.EliminarContratacionProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Delete");
        }


        public static ContratacionProducto CambiarModelaClase(ContratacionProductoViewModel model)
        {
            var contratacionproducto = new ContratacionProducto()
            {                
                Id = model.Id,
                ContratacionId = (int)model.ContratacionId,
                ProductoId = (int)model.ProductoId,
                Contratacion = model.Contratacion,
                Producto = model.Producto,
                Unidad= model.Unidad,
                Precio = model.Precio,
                Fecha = DateTime.Now,
                Activo = true
            };
            return contratacionproducto;
        }
        public static ContratacionProductoViewModel CambiarClaseaModel(ContratacionProducto contratacionproducto)
        {
            var model = new ContratacionProductoViewModel()
            {
            Contratacion = contratacionproducto.Contratacion,
            ContratacionId = contratacionproducto.Contratacion.Id,
            Activo = contratacionproducto.Activo
            };
            return model;
        }

        [HttpGet]
        public IActionResult GetPrecio(int Id)
        {
            var precio = _productoService.ObtenerPrecio(Id); // Reemplaza esto con tu lógica para obtener el precio
            return Json(precio);
        }
    }
}
