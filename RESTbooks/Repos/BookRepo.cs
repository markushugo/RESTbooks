using RESTbooks.Models;

namespace RESTbooks.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly List<Book> books = new();
        private int nextId = 1;

        public BookRepo(bool includeData) 
        {
            if (includeData)
            {
                AddBook(new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 99.95 });
                AddBook(new Book { Id = 2, Title = "1984", Author = "George Orwell", Price = 89.50 });
                AddBook(new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 95.00 });
                AddBook(new Book { Id = 4, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Price = 85.75 });
                AddBook(new Book { Id = 5, Title = "Moby Dick", Author = "Herman Melville", Price = 110.00 });
                AddBook(new Book { Id = 6, Title = "Pride and Prejudice", Author = "Jane Austen", Price = 92.30 });
                AddBook(new Book { Id = 7, Title = "The Hobbit", Author = "J.R.R. Tolkien", Price = 120.00 });
                AddBook(new Book { Id = 8, Title = "War and Peace", Author = "Leo Tolstoy", Price = 150.00 });
                AddBook(new Book { Id = 9, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Price = 105.20 });
                AddBook(new Book { Id = 10, Title = "The Alchemist", Author = "Paulo Coelho", Price = 88.80 });
                AddBook(new Book { Id = 11, Title = "Brave New World", Author = "Aldous Huxley", Price = 90.00 });
                AddBook(new Book { Id = 12, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Price = 200.00 });
                AddBook(new Book { Id = 13, Title = "The Kite Runner", Author = "Khaled Hosseini", Price = 97.45 });
                AddBook(new Book { Id = 14, Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Price = 130.00 });
                AddBook(new Book { Id = 15, Title = "The Da Vinci Code", Author = "Dan Brown", Price = 99.99 });
                AddBook(new Book { Id = 16, Title = "The Hunger Games", Author = "Suzanne Collins", Price = 85.00 });
                AddBook(new Book { Id = 17, Title = "The Book Thief", Author = "Markus Zusak", Price = 93.60 });
                AddBook(new Book { Id = 18, Title = "Jane Eyre", Author = "Charlotte Brontë", Price = 87.25 });
                AddBook(new Book { Id = 19, Title = "Wuthering Heights", Author = "Emily Brontë", Price = 84.90 });
                AddBook(new Book { Id = 20, Title = "The Chronicles of Narnia", Author = "C.S. Lewis", Price = 140.00 });
                AddBook(new Book { Id = 21, Title = "Animal Farm", Author = "George Orwell", Price = 75.00 });
                AddBook(new Book { Id = 22, Title = "The Shining", Author = "Stephen King", Price = 110.50 });
                AddBook(new Book { Id = 23, Title = "Dracula", Author = "Bram Stoker", Price = 89.00 });
                AddBook(new Book { Id = 24, Title = "Frankenstein", Author = "Mary Shelley", Price = 82.40 });
                AddBook(new Book { Id = 25, Title = "The Road", Author = "Cormac McCarthy", Price = 94.75 });
            
            };
        }

        public Book AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.Id = nextId++;
            books.Add(book);
            return book;
        }

        public Book? GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public Book? DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book is not null)
            {
                books.Remove(book);
                return book;
            }
            return null;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book? UpdateBook(int id, Book book)
        {
            var existingBook = GetBookById(id);
            if (existingBook is not null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Price = book.Price;
                return existingBook;
            }
            return null;
        }
    }
}
