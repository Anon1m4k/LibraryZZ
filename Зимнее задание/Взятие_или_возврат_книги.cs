using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание
{
    public class Взятие_или_возврат_книги
    {
        private Запись_CSV_файла записьCSV;
        public Взятие_или_возврат_книги(Запись_CSV_файла записьCSV)
        {
            this.записьCSV = записьCSV;
        }

        public Выбор_действия Выбор_действия
        {
            get => default;
            set
            {
            }
        }

        public void Добавление_записи()
        {
            Console.Write("Введите название книги: ");
            string название = Console.ReadLine();
            var книги = записьCSV.Прочитать_из_CSV();
            var книга = книги.FirstOrDefault(b => b.Название.Equals(название, StringComparison.OrdinalIgnoreCase));

            if (книга != null)
            {
                Console.Write("Введите ФИО человека, который взял книгу: ");
                книга.Записано_за = Console.ReadLine();
                записьCSV.Добавить_в_CSV(книга, false);
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
        public void Возврат_записи()
        {
            Console.Write("Введите название книги: ");
            string название = Console.ReadLine();
            var книги = записьCSV.Прочитать_из_CSV();
            var книга = книги.FirstOrDefault(b => b.Название.Equals(название, StringComparison.OrdinalIgnoreCase));

            if (книга != null)
            {
                книга.Записано_за = "";
                записьCSV.Добавить_в_CSV(книга, false);
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }
}