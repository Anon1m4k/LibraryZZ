using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public class SelectAction
    {
        private List<Book> books;
        private string filePath = "library.csv";
        private int GetNextId() => books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;

        public SelectAction()
        {
            books = ActionWithCSVFile.LoadBooks(filePath);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить книгу\n2. Удалить книгу\n3. Поиск по автору\n4. Поиск по названию\n5. Записать книгу\n6. Вернуть книгу\n7. Выход");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": DeleteBook(); break;
                    case "3": SearchByAuthor(); break;
                    case "4": SearchByTitle(); break;
                    case "5": TakeBook(); break;
                    case "6": ReturnBook(); break;
                    case "7": ActionWithCSVFile.SaveBooks(filePath, books); return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }
        private void AddBook()
        {
            Console.WriteLine("Введите название, автора, издательство, год, количество экземпляров:");
            var title = Console.ReadLine();
            var author = Console.ReadLine();
            var publisher = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out int year) || !int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Год и количество экземпляров должны вводиться числами.");
                return;
            }

            int nextId = GetNextId();
            for (int i = 0; i < count; i++)
            {
                books.Add(new Book
                {
                    Id = nextId + i,
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    Year = year
                });
            }

            Console.WriteLine($"Добавлено {count} экземпляров книги.");
        }

        private void DeleteBook()
        {
            Console.WriteLine("Введите ID книги для удаления:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("ID должно вводиться числом.");
                return;
            }

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' (ID: {id}) удалена.");
        }

        private void SearchByAuthor()
        {
            Console.WriteLine("Введите автора:");
            SearchBooks.SearchByAuthor(books, Console.ReadLine());
        }

        private void SearchByTitle()
        {
            Console.WriteLine("Введите название:");
            SearchBooks.SearchByTitle(books, Console.ReadLine());
        }

        private void TakeBook()
        {
            Console.WriteLine("Введите ID книги и ФИО:");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            TakingByReader.TakeBook(books, id, Console.ReadLine());
        }

        private void ReturnBook()
        {
            Console.WriteLine("Введите ID книги:");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            TakingByReader.ReturnBook(books, id);
        }
    }
}
