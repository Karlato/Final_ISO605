using Final_ISO605.Core;
using Final_ISO605.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_ISO605.UI.Controllers
{
    public class TipoEgresoController : Controller
    {
        private readonly ITipoEgresoRepository _tipoEgresoRepo;

        public TipoEgresoController(ITipoEgresoRepository tipoEgresoRepo)
        {
            _tipoEgresoRepo = tipoEgresoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var tiposEgresos = await _tipoEgresoRepo.GetAll();
            return View(tiposEgresos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new TipoEgreso());
            }
            else
            {
                try
                {
                    TipoEgreso tipoEgreso = await _tipoEgresoRepo.GetById(id);

                    if (tipoEgreso != null)
                    {
                        return View(tipoEgreso);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] =$"Detalles del Tipo de Egreso no encontrados con ID : {id}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(TipoEgreso Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(Model.ID == 0)
                    {
                        await _tipoEgresoRepo.Add(Model);
                        TempData["successMessage"] = "Tipo de Egreso creado correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _tipoEgresoRepo.Update(Model);
                        TempData["successMessage"] = "Tipo de Egreso alterado correctamente.";
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
            TipoEgreso tipoEgreso = await _tipoEgresoRepo.GetById(id);
            try
            {
                if (tipoEgreso != null)
                {
                    return View(tipoEgreso);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Detalles del Tipo de Egreso no encontrados con ID : {id}";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _tipoEgresoRepo.Delete(id);
                TempData["successMessage"] = "Tipo de Egreso borrado correctamente.";
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
