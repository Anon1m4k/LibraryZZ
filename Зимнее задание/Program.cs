using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Зимнее_задание
{
    internal class Program
    {
        public Выбор_действия Выбор_действия
        {
            get => default;
            set
            {
            }
        }

        static void Main(string[] args) //Точка входа в программу
        {            
            Выбор_действия выбор_действия = new Выбор_действия(); //Создание экземпляра класса Выбор_действия
            выбор_действия.Выполнить(); //Вызов метода Выполнить() из класса Выбор_действия
        }
    }
}