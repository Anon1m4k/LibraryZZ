using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание__Библиотека_
{
    public static class ActionWithCSVFile
    {
        public static List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new List<Book>();
            if (!File.Exists(filePath)) return books;

            foreach (var line in File.ReadAllLines(filePath).Skip(1))
            {
                string[] parts = line.Split(',');
                if (parts.Length < 8) continue;

                var book = ParseBook(parts);
                books.Add(book);
            }

            return books;
        }

        private static Book ParseBook(string[] parts)
        {
            int id = int.Parse(parts[0]);
            string title = parts[1];
            string author = parts[2];
            string publisher = parts[3];
            int year = int.Parse(parts[4]);
            string holderName = parts[5];

            if (!string.IsNullOrEmpty(holderName))
            {
                return new TakenBook
                {
                    Id = id,
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    Year = year,
                    HolderName = holderName,
                    CheckoutDate = DateTime.Parse(parts[6]),
                    DueDate = DateTime.Parse(parts[7])
                };
            }

            return new Book
            {
                Id = id,
                Title = title,
                Author = author,
                Publisher = publisher,
                Year = year
            };
        }

        public static void SaveBooks(string filePath, List<Book> books)
        {
            var lines = new List<string> { "Id,Title,Author,Publisher,Year,HolderName,CheckoutDate,DueDate" };

            foreach (var book in books)
            {
                if (book is TakenBook takenBook)
                {
                    lines.Add($"{takenBook.Id},{takenBook.Title}," +
                              $"{takenBook.Author},{takenBook.Publisher}," +
                              $"{takenBook.Year},{takenBook.HolderName}," +
                              $"{takenBook.CheckoutDate:yyyy-MM-dd}," +
                              $"{takenBook.DueDate:yyyy-MM-dd}");
                }
                else
                {
                    lines.Add($"{book.Id},{book.Title}," +
                              $"{book.Author},{book.Publisher}," +
                              $"{book.Year},,,");
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}