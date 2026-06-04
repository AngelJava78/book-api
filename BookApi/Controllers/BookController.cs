using BookApi.Business;
using BookApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookLogic logic;
    public BookController(IBookLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet]
    public List<Book> Get()
    {
        return logic.Get();
    }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book book)
    {
        if (book == null)
            return BadRequest();

        var createdBook = logic.Create(book);

        return Ok(createdBook);
    }


    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = logic.GetById(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet("title/{title}")]
    public ActionResult<IEnumerable<Book>> GetByTitle(string title)
    {
        var books = logic.GetByTitle(title);
        if (books == null)
            return NotFound();

        return Ok(books);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = logic.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPut]
    public IActionResult Update([FromBody] Book book)
    {
        if (book == null || book.Id <= 0)
        {
            return BadRequest();
        }

        var updated = logic.Update(book);

        if (!updated)
        {
            return NotFound(book);
        }
        var result = logic.GetById(book.Id);
        if (result == null)
        {
            return NotFound(book);
        }
        return Ok(result);
    }

}
