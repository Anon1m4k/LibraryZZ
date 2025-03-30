using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание
{
    public class Поиск_книг
    {
        private List<Записанная_книга> книги;
        public Поиск_книг(List<Записанная_книга> книги)
        {
            this.книги = книги;
        }
        public void Поиск_по_автору()
        {
            Console.Write("Введите автора для поиска: ");
            string автор = Console.ReadLine();
            var найденные_книги = книги.Where(b => b.Автор.Equals(автор, StringComparison.OrdinalIgnoreCase)).ToList();

            if (найденные_книги.Any())
            {
                Console.WriteLine("Найденные книги: ");
                foreach (var книга in найденные_книги)
                {
                    Console.WriteLine(книга);
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }
        public void Поиск_по_букве()
        {
            Console.Write("Введите букву для поиска: ");
            char буква = Console.ReadKey().KeyChar;
            Console.ReadKey(); //=)
            var найденные_книги = книги.Where(b => b.Название.StartsWith(буква.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();

            if (найденные_книги.Any())
            {
                Console.WriteLine("Найденные книги:");
                foreach (var книга in найденные_книги)
                {
                    Console.WriteLine(книга);
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }
    }
}