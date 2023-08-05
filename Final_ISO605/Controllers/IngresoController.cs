using Final_ISO605.Core;
using Final_ISO605.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_ISO605.UI.Controllers
{
    public class IngresoController : Controller
    {
        private readonly IIngresoRepository _ingresoRepo;
        private readonly ITipoIngresoRepository _tipoIngresoRepo;

        public IngresoController(IIngresoRepository ingresoRepo, ITipoIngresoRepository tipoIngresoRepo)
        {
            _ingresoRepo = ingresoRepo;
            _tipoIngresoRepo = tipoIngresoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var ingresos = await _ingresoRepo.GetAll();
            return View(ingresos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Ingreso());
            }
            else
            {
                try
                {
                    Ingreso ingreso = await _ingresoRepo.GetById(id);

                    if (ingreso != null)
                    {
                        return View(ingreso);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = $"Detalles del Ingreso no encontrados con ID : {id}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Ingreso Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Model.ID == 0)
                    {
                        await _ingresoRepo.Add(Model);
                        TempData["successMessage"] = "Ingreso creado correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _ingresoRepo.Update(Model);
                        TempData["successMessage"] = "Ingreso alterado correctamente.";
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
            Ingreso ingreso = await _ingresoRepo.GetById(id);
            try
            {
                if (ingreso != null)
                {
                    return View(ingreso);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Detalles del Ingreso no encontrados con ID : {id}";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ingresoRepo.Delete(id);
                TempData["successMessage"] = "Ingreso borrado correctamente.";
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
