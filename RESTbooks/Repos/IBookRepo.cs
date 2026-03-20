using RESTbooks.Models;

namespace RESTbooks.Repos
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book? GetBookById(int id);
        Book AddBook(Book book);
        Book? UpdateBook(int id, Book book);
        Book? DeleteBook(int id);
    }
}
