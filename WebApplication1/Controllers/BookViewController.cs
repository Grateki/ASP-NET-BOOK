using System;
using System.Threading.Tasks;
using ControleDeLivros.Models;
using ControleDeLivros.Services;
using ControleDeLivros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("Livro")]

public class BookViewController : Controller
{
    private readonly IBookService _booksService;

    public BookViewController(IBookService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    [Route("Livro/Index")]
    public async Task<IActionResult> Index()
    {
        var books = await _booksService.GetAllBooksAsync();
        return View(books);
    }

    [HttpGet]
    [Route("Details/{BookId}")]
    public async Task<IActionResult> Details(int BookId)
    {
        var book = await _booksService.GetBookByIdAsync(BookId);

        if (book != null)
        {
            return View(book);
        }
        else
        {
            return NotFound($"Livro com ID {BookId} não encontrado");
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
    public async Task<IActionResult> Create([FromBody] BookModel book)
    {
        try
        {
            var addedBook = await _booksService.AddBookAsync(book);
            return RedirectToAction("Details", new { BookId = addedBook.BookId });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao adicionar livro: {ex.Message}");
            return View(book);
        }
    }

    [HttpGet]
    [Route("Edit/{BookId}")]
    public async Task<IActionResult> Edit(int BookId)
    {
        var book = await _booksService.GetBookByIdAsync(BookId);

        if (book != null)
        {
            return View(book);
        }
        else
        {
            return NotFound($"Livro com ID {BookId} não encontrado");
        }
    }

    [HttpPut]
    [Route("Edit/{BookId}")]
    public async Task<IActionResult> Edit(int BookId, [FromBody] BookModel book)
    {
        try
        {
            var updatedBook = await _booksService.UpdateBookAsync(BookId, book);

            if (updatedBook != null)
            {
                return RedirectToAction("Details", new { BookId = updatedBook.BookId });
            }
            else
            {
                return NotFound($"Livro com ID {BookId} não encontrado");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao atualizar livro: {ex.Message}");
            return View(book);
        }
    }

    [HttpGet]
    [Route("Delete/{BookId}")]
    public async Task<IActionResult> Delete(int BookId)
    {
        var book = await _booksService.GetBookByIdAsync(BookId);

        if (book != null)
        {
            return View(book);
        }
        else
        {
            return NotFound($"Livro com ID {BookId} não encontrado");
        }
    }

    [HttpDelete]
    [Route("Delete/{BookId}")]
    public async Task<IActionResult> DeleteConfirmed(int BookId)
    {
        try
        {
            bool deleted = await _booksService.DeleteBookAsync(BookId);

            if (deleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound($"Livro com ID {BookId} não encontrado");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao excluir livro: {ex.Message}");
            return RedirectToAction("Delete", new { BookId = BookId });
        }
    }
}
