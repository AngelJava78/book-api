using BookApi.Entities;
using Npgsql;
using Dapper;

namespace BookApi.Data;

public class BookRepository : IBookRepository
{
    private readonly string connectionString;
    public BookRepository(IConfiguration configuration)
    {
        
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = configuration["Database:Server"],
            Username = configuration["Database:User"],
            Password = configuration["Database:Password"],
            Database = configuration["Database:Database"],
            Port = 5432
        };

        connectionString = builder.ConnectionString;


    }
    public Book Create(Book book)
    {

        var query = @"
            INSERT INTO public.books
            (title, author, description, year, genre, createddate)
            VALUES
            (@Title, @Author, @Description, @Year, @Genre, now())
            RETURNING id;";

        using var connection = new NpgsqlConnection(connectionString);
        var parameters = new
        {
            book.Title,
            book.Author,
            book.Description,
            book.Year,
            book.Genre
        };
        int id = connection.ExecuteScalar<int>(query, parameters);
        book.Id = id;
        return book;

    }

    public bool Delete(int id)
    {
        var query = "DELETE FROM Books WHERE ID = @id";
        using var connection = new NpgsqlConnection(connectionString);
        var rowsAffected = connection.Execute(query, new { id });
        return rowsAffected > 0;
    }

    public List<Book> Get()
    {
        var query = "SELECT * FROM Books";
        using var connection = new NpgsqlConnection(connectionString);
        List<Book> books = connection.Query<Book>(query).ToList();
        return books;
    }

    public Book GetById(int id)
    {
        var query = "SELECT * FROM Books WHERE Id = @Id";
        using var connection = new NpgsqlConnection(connectionString);

        Book book = connection.QueryFirstOrDefault<Book>(query, new { id });
        return book;
    }

    public Book GetByTitle(string title)
    {
        var query = "SELECT * FROM Books WHERE title = @title";
        using var connection = new NpgsqlConnection(connectionString);

        Book book = connection.QueryFirstOrDefault<Book>(query, new { title });
        return book;
    }



    public bool Update(Book book)
    {
        var query = @"
        UPDATE public.books
        SET
            title = @Title,
            author = @Author,
            description = @Description,
            year = @Year,
            genre = @Genre,
            updateddate = now()
        WHERE id = @Id;";

        using var connection = new NpgsqlConnection(connectionString);

        var rows = connection.Execute(query, new
        {
            book.Id,
            book.Title,
            book.Author,
            book.Description,
            book.Year,
            book.Genre

        });

        return rows > 0;
    }

}
