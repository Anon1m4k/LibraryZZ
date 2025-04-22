using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public class Library
    {
        private string _filePath = "library.csv";

        private List<Book> _books;

        public Library(List<Book> books)
        {
            _books = books;
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

        public void DeleteBook(Book book)
        {
            _books.Remove(book);
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