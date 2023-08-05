using Final_ISO605.Core;
using Final_ISO605.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_ISO605.UI.Controllers
{
    public class TipoPagoController : Controller
    {
        private readonly ITipoPagoRepository _tipoPagoRepo;

        public TipoPagoController(ITipoPagoRepository tipoPagoRepo)
        {
            _tipoPagoRepo = tipoPagoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var tiposPagos = await _tipoPagoRepo.GetAll();
            return View(tiposPagos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new TipoPago());
            }
            else
            {
                try
                {
                    TipoPago tipoPago = await _tipoPagoRepo.GetById(id);

                    if (tipoPago != null)
                    {
                        return View(tipoPago);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = $"Detalles del Tipo de Pago no encontrados con ID : {id}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(TipoPago Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Model.ID == 0)
                    {
                        await _tipoPagoRepo.Add(Model);
                        TempData["successMessage"] = "Tipo de Pago creado correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _tipoPagoRepo.Update(Model);
                        TempData["successMessage"] = "Tipo de Pago alterado correctamente.";
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
            TipoPago tipoPago = await _tipoPagoRepo.GetById(id);
            try
            {
                if (tipoPago != null)
                {
                    return View(tipoPago);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Detalles del Tipo de Pago no encontrados con ID : {id}";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _tipoPagoRepo.Delete(id);
                TempData["successMessage"] = "Tipo de Pago borrado correctamente.";
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