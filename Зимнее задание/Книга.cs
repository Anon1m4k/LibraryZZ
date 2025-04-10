using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Зимнее_задание
{
    public class Книга
    {
        public string Название { get; set; } //Свойство для хранения названия книги
        public string Автор { get; set; } //Свойство для хранения автора книги
        public string Издательство { get; set; } //Свойство для хранения издательства книги
        public int Год_издания { get; set; } //Свойство для хранения года издания книги

        public override string ToString() //Переопределённый метод ToString() для форматированного представления объекта Книга
        {
           return $"{Название} - {Автор} ({Год_издания}, {Издательство})";
        }
    }
}