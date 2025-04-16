using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public static class TakingByReader
    {
        public static void TakeBook(List<Book> books, int bookId, string holderName)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            if (book is TakenBook)
            {
                Console.WriteLine("Книга уже взята.");
                return;
            }

            var takenBook = new TakenBook
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Year = book.Year,
                HolderName = holderName,
                CheckoutDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };

            int index = books.IndexOf(book);
            books[index] = takenBook;
            Console.WriteLine($"Книга '{book.Title}' записана за '{holderName}'.");
        }

        public static void ReturnBook(List<Book> books, int bookId)
        {
            var takenBook = books.OfType<TakenBook>().FirstOrDefault(b => b.Id == bookId);
            if (takenBook == null)
            {
                Console.WriteLine("Книга не найдена или не была взята.");
                return;
            }

            var book = new Book
            {
                Id = takenBook.Id,
                Title = takenBook.Title,
                Author = takenBook.Author,
                Publisher = takenBook.Publisher,
                Year = takenBook.Year
            };

            int index = books.IndexOf(takenBook);
            books[index] = book;
            Console.WriteLine("Книга возвращена.");
        }
    }
}
