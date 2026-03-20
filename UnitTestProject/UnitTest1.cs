using RESTbooks.Models;
using RESTbooks.Repos;
using System.Linq;
using Xunit;

namespace UnitTestProject
{
    public class BookRepoTests
    {
        [Fact]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var repo = new BookRepo(false);
            repo.AddBook(new Book { Title = "Test Book 1", Author = "Author 1", Price = 100.0 });
            repo.AddBook(new Book { Title = "Test Book 2", Author = "Author 2", Price = 200.0 });

            // Act
            var books = repo.GetAllBooks();

            // Assert
            Assert.Equal(2, books.Count());
        }

        [Fact]
        public void GetBookById_ExistingId_ReturnsBook()
        {
            // Arrange
            var repo = new BookRepo(false);
            var added = repo.AddBook(new Book { Title = "Test Book", Author = "Author", Price = 50.0 });

            // Act
            var book = repo.GetBookById(added.Id);

            // Assert
            Assert.NotNull(book);
            Assert.Equal("Test Book", book.Title);
            Assert.Equal("Author", book.Author);
            Assert.Equal(50.0, book.Price);
        }
    }
}
