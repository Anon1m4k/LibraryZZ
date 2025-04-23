using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public static class SearchBooks
    {
        public static void SearchByAuthor(List<Book> books, string author)
        {
            List<Book> foundBooks = books.Where(b => b.Author.Contains(author)).ToList();

            if (foundBooks.Count() == 0)
            {
                Console.WriteLine("Книги не найдены.");
                return;
            } 
            PrintBooks(foundBooks);
        }

        public static void SearchByTitle(List<Book> books, string title)
        {
            List<Book> foundBooks = books.Where(b => b.Title.Contains(title)).ToList();

            if (foundBooks.Count() == 0)
            {
                Console.WriteLine("Книги не найдены.");
                return;
            }
            PrintBooks(foundBooks);
        }

        private static void PrintBooks(List<Book> books)
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
    }
}
