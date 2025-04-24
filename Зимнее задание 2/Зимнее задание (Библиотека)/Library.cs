using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public class Library
    {
        private List<Book> _books;
        private const string _filePath = "library.csv";

        public Library()
        {
            _books = ActionWithCSVFile.LoadBooks(_filePath);
        }

        public void AddBook(string title, string author, string publisher, int year, int count)
        {
            int nextId = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            for (int i = 0; i < count; i++)
            {
                _books.Add(new Book
                {
                    Id = nextId + i,
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    Year = year
                });
            }
        }

        public Book DeleteBook(Book book)
        {
            _books.Remove(book);
            return book;
        }

        public List<Book> SearchByAuthor(List<Book> books, string author)
        {
            List<Book> foundBooks = books.Where(b => b.Author.Contains(author)).ToList();
            return foundBooks;
        }

        public List<Book> SearchByTitle(List<Book> books, string title)
        {
            List<Book> foundBooks = books.Where(b => b.Title.Contains(title)).ToList();
            return foundBooks;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}