using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public class SelectAction
    {
        private Library _library = new Library();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить книгу\n2. Удалить книгу\n3. Поиск по автору\n4. Поиск по названию или частичному совпадению\n5. Записать книгу\n6. Вернуть книгу\n7. Выход");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": DeleteBook(); break;
                    case "3": SearchByAuthor(); break;
                    case "4": SearchByTitle(); break;
                    case "5": TakeBook(); break;
                    case "6": ReturnBook(); break;
                    case "7": ActionWithCSVFile.SaveBooks(_library.GetFilePath(), _library.GetAllBooks()); return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Введите название, автора, издательство, год издания, количество экземпляров:");
            string title = Console.ReadLine();
            string author = Console.ReadLine();
            string publisher = Console.ReadLine();

            if (!int.TryParse(Console.ReadLine(), out int year) || !int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Год издания и количество экземпляров должны вводиться числами.");
                return;
            }

            if (year <= 0 || count <= 0)
            {
                Console.WriteLine("Год издания и количество экземпляров должны больше нуля.");
                return;
            }

            _library.AddBook(title, author, publisher, year, count);
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

            if (id <= 0)
            {
                Console.WriteLine("ID должно быть больше нуля.");
                return;
            }

            Book book = _library.GetAllBooks().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            _library.DeleteBook(book);

            Console.WriteLine($"Книга '{book.Title}' (ID: {id}) удалена.");
        }

        private void SearchByAuthor()
        {
            Console.WriteLine("Введите автора:");
            string author = Console.ReadLine();

            if (author == "")
            {
                Console.WriteLine("Введён пустой автор.");
                return;
            }

            List<Book> foundBooks = _library.SearchByAuthor(_library.GetAllBooks(), author);

            if (foundBooks.Count() == 0)
            {
                Console.WriteLine("Книги не найдены.");
                return;
            }
            PrintBooks(foundBooks);
        }

        private void SearchByTitle()
        {
            Console.WriteLine("Введите название:");
            string name = Console.ReadLine();

            List<Book> foundBooks = _library.SearchByTitle(_library.GetAllBooks(), name);

            if (foundBooks.Count() == 0)
            {
                Console.WriteLine("Книги не найдены.");
            }
            PrintBooks(foundBooks);
        }

        public void PrintBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"ID: {book.Id} | {book.Title} - {book.Author} | " +
                                  $"{book.Publisher} ({book.Year})");

                if (book is TakenBook takenBook)
                {
                    Console.WriteLine($" На руках у: {takenBook.HolderName} | " +
                                    $"Взята: {takenBook.CheckoutDate:dd.MM.yyyy} | " +
                                    $"Вернуть до: {takenBook.DueDate:dd.MM.yyyy}");
                }
            }
        }

        private void TakeBook()
        {
            Console.WriteLine("Введите ID книги и ФИО:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID должно вводиться числом.");
                return;
            }
            if (id <= 0)
            {
                Console.WriteLine("ID должно быть больше нуля.");
                return;
            }
            TakingByReader.TakeBook(_library.GetAllBooks(), id, Console.ReadLine());
        }

        private void ReturnBook()
        {
            Console.WriteLine("Введите ID книги:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID должно вводиться числом.");
                return;
            }
            if (id <= 0)
            {
                Console.WriteLine("ID должно быть больше нуля.");
                return;
            }
            TakingByReader.ReturnBook(_library.GetAllBooks(), id);
        }
    }
}