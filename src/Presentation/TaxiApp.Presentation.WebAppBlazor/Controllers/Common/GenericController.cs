using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Common;
using TaxiApp.Presentation.WebAppBlazor.Models;

namespace TaxiApp.Presentation.Web.Controllers.Common;

public class GenericController<TDto, TEntity> : Controller
    where TDto : class
    where TEntity : class
{
    private readonly IGenericService<TDto, TEntity> _service;

    public GenericController(IGenericService<TDto, TEntity> service)
    {
        _service = service;
    }

    // GET: /[controller]/
    public virtual async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();
        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return View(new List<TDto>()); // fallback
        }

        return View(result.Data);
    }

    // GET: /[controller]/Details/5
    public virtual async Task<IActionResult> Details([FromRoute]int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (!result.IsSuccess || result.Data == null)
        {
            return View("Error", new ErrorViewModel { Message = result.Message ?? "Elemento no encontrado." });
        }

        return View(result.Data);
    }

    // GET: /[controller]/Create
    public virtual IActionResult Create()
    {
        return View();
    }

    // POST: /[controller]/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Create(TDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _service.AddAsync(dto);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /[controller]/Edit/5
    public virtual async Task<IActionResult> Edit(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (!result.IsSuccess || result.Data == null)
        {
            return View("Error", new ErrorViewModel { Message = result.Message ?? "Elemento no encontrado." });
        }

        return View(result.Data);
    }

    // POST: /[controller]/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Edit(int id, TDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _service.UpdateAsync(dto);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /[controller]/Delete/5
    public virtual async Task<IActionResult> Delete(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (!result.IsSuccess || result.Data == null)
        {
            return View("Error", new ErrorViewModel { Message = result.Message ?? "Elemento no encontrado." });
        }

        return View(result.Data);
    }

    // POST: /[controller]/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return RedirectToAction(nameof(Delete), new { id });
        }

        return RedirectToAction(nameof(Index));
    }
}
