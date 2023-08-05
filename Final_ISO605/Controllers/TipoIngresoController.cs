using Final_ISO605.Core;
using Final_ISO605.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_ISO605.UI.Controllers
{
    public class TipoIngresoController : Controller
    {
        private readonly ITipoIngresoRepository _tipoIngresoRepo;

        public TipoIngresoController(ITipoIngresoRepository tipoIngresoRepo)
        {
            _tipoIngresoRepo = tipoIngresoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var tiposIngresos = await _tipoIngresoRepo.GetAll();
            return View(tiposIngresos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new TipoIngreso());
            }
            else
            {
                try
                {
                    TipoIngreso tipoIngreso = await _tipoIngresoRepo.GetById(id);

                    if (tipoIngreso != null)
                    {
                        return View(tipoIngreso);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = $"Detalles del Tipo de Ingreso no encontrados con ID : {id}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(TipoIngreso Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Model.ID == 0)
                    {
                        await _tipoIngresoRepo.Add(Model);
                        TempData["successMessage"] = "Tipo de Ingreso creado correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _tipoIngresoRepo.Update(Model);
                        TempData["successMessage"] = "Tipo de Ingreso alterado correctamente.";
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["errorMessage"] = "Estado del Modelo es invalido.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            TipoIngreso tipoIngreso = await _tipoIngresoRepo.GetById(id);
            try
            {
                if (tipoIngreso != null)
                {
                    return View(tipoIngreso);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Detalles del Tipo de Ingreso no encontrados con ID : {id}";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _tipoIngresoRepo.Delete(id);
                TempData["successMessage"] = "Tipo de Ingreso borrado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
