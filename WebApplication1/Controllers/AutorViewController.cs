using System;
using System.Threading.Tasks;
using ControleDeLivros.Models;
using ControleDeLivros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("Autor")]
[Area("Autor")]
public class AutorViewController : Controller
{
    private readonly IAutorService _autorService;

    public AutorViewController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var autores = await _autorService.GetAuthorsAsync();
        return View(autores);
    }

    [HttpGet]
    [Route("Details/{AuthorId}")]
    public async Task<IActionResult> Details(int id)
    {
        var autor = await _autorService.GetAuthorByIdAsync(id);

        if (autor != null)
        {
            return View(autor);
        }
        else
        {
            return NotFound($"Autor com ID {id} não encontrado");
        }
    }
    [HttpGet]
    [Route("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(AuthorModel autor)
    {
        try
        {
            var addedAutor = await _autorService.AddAuthorAsync(autor);
            return RedirectToAction("Details", new { id = addedAutor.AuthorId });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao adicionar autor: {ex.Message}");
            return View(autor);
        }
    }

    [HttpGet]
    [Route("Edit/{AuthorId}")]
    public async Task<IActionResult> Edit(int id)
    {
        var autor = await _autorService.GetAuthorByIdAsync(id);

        if (autor != null)
        {
            return View(autor);
        }
        else
        {
            return NotFound($"Autor com ID {id} não encontrado");
        }
    }

    [HttpPut]
    [Route("Edit/{AuthorId}")]
    public async Task<IActionResult> Edit(int id, AuthorModel autor)
    {
        try
        {
            var updatedAutor = await _autorService.UpdateAuthorAsync(id, autor);

            if (updatedAutor != null)
            {
                return RedirectToAction("Details", new { id = updatedAutor.AuthorId });
            }
            else
            {
                return NotFound($"Autor com ID {id} não encontrado");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao atualizar autor: {ex.Message}");
            return View(autor);
        }
    }

    [HttpGet]
    [Route("Delete/{AuthorId}")]
    public async Task<IActionResult> Delete(int id)
    {
        var autor = await _autorService.GetAuthorByIdAsync(id);

        if (autor != null)
        {
            return View(autor);
        }
        else
        {
            return NotFound($"Autor com ID {id} não encontrado");
        }
    }

    [HttpDelete]
    [Route("Delete/{AuthorId}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            bool deleted = await _autorService.DeleteAuthorAsync(id);

            if (deleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound($"Autor com ID {id} não encontrado");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao excluir autor: {ex.Message}");
            return RedirectToAction("Delete", new { id = id });
        }
    }
}
