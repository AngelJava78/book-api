using BookApi.Entities;

namespace BookApi.Data;
public interface IBookRepository
{
    Book Create(Book book);
    bool Delete(int id);
    List<Book> Get();
    Book GetById(int id);
    Book GetByTitle(string title);
    bool Update(Book book);
}