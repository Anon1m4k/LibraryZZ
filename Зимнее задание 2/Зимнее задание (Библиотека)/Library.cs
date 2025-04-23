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

        public void DeleteBook(int id)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }
            _books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' (ID: {id}) удалена.");
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