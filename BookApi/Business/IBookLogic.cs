using BookApi.Entities;

namespace BookApi.Business;

public interface IBookLogic
{
    public List<Book> Get();
    public Book GetByTitle(string name);
    public Book GetById(int id);
    public Book Create(Book book);
    public bool Update(Book book);
    public bool Delete(int id);

}
