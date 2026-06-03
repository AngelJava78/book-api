using BookApi.Data;
using BookApi.Entities;

namespace BookApi.Business;

public class BookLogic : IBookLogic
{

    private readonly IBookRepository repository;
    public BookLogic(IBookRepository repository)
    {
        this.repository = repository;
    }
    public Book Create(Book book)
    {
        return repository.Create(book);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public List<Book> Get()
    {
        return repository.Get();
    }

    public Book GetById(int id)
    {
        return repository.GetById(id);
    }

    public Book GetByTitle(string name)
    {
        return repository.GetByTitle(name);
    }

    public bool Update(Book book)
    {
        return repository.Update(book);
    }
}
