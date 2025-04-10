﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace Зимнее_задание
{    
    public class Запись_CSV_файла //Класс для работы с CSV файлом, содержащим информацию о книгах
    {
        private const string Путь_к_файлу = "Библиотека.csv"; //Константа, определяющая путь к CSV файлу

        public Выбор_действия Выбор_действия
        {
            get => default;
            set
            {
            }
        }

        public void Добавить_в_CSV(Записанная_книга книга, bool перезаписатьФайл)
        {            
            if (перезаписатьФайл)
            {
                var csv = new StringBuilder();
                var строка = $"{книга.Название},{книга.Автор},{книга.Издательство},{книга.Год_издания},{книга.Записано_за}"; //работает
                csv.AppendLine(строка);
                File.AppendAllText(Путь_к_файлу, csv.ToString(), Encoding.UTF8);   //Записываем данные в CSV файл с использованием кодировки UTF-8
                Console.WriteLine("Книга сохранена.");
                csv = null;
            }
            else
            {
                var строки = File.ReadAllLines(Путь_к_файлу).ToList();             
                var индекс = строки.FindIndex(s => s.Split(',')[0] == книга.Название);   //Найти строку, соответствующую названию книги

                if (индекс >= 0)
                {
                    var новаяСтрока = $"{книга.Название},{книга.Автор},{книга.Издательство},{книга.Год_издания},{книга.Записано_за},{DateTime.Now}"; //Формируем новую строку с обновленными данными
                    строки[индекс] = новаяСтрока;  //Обновляем строку в списке
                    File.WriteAllLines(Путь_к_файлу, строки, Encoding.UTF8);  //Перезаписываем файл с обновленным списком строк
                    if (книга.Записано_за != "")
                    {
                        Console.WriteLine($"Книга '{книга.Название}' записана за {книга.Записано_за}");
                    }    
                    else
                    {
                        Console.WriteLine("Книга возвращена");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Книга с названием '{книга.Название}' не найдена.");
                }
            }
        }
        public List<Записанная_книга> Прочитать_из_CSV() // Метод для чтения данных из CSV файла
        {
            var книги = new List<Записанная_книга>(); // Создание пустого списка для хранения книг

            if (File.Exists(Путь_к_файлу)) // Проверка существования CSV файла
            {
                var строки = File.ReadAllLines(Путь_к_файлу); // Чтение всех строк из CSV файла
                foreach (var строка in строки) // Проход по каждой строке файла
                {
                    var значение = строка.Split(','); // Разделение строки по запятым для получения значений полей книги
                    var книга = new Записанная_книга // Создание объекта книги с полученными значениями
                    {
                        Название = значение[0],
                        Автор = значение[1],
                        Издательство = значение[2],
                        Год_издания = Convert.ToInt32(значение[3]),
                        Записано_за = значение[4]
                    };
                    книги.Add(книга);
                }                     
            }
            else
            {
                Console.WriteLine("CSV файл не найден. Создан новый файл для сохранения.");
            }
            return книги;
        }
    }
}