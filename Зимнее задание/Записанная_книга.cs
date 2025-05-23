﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зимнее_задание
{
    public class Записанная_книга: Книга //Класс 'Записанная_книга' наследуется от класса 'Книга'
    {
        public string Записано_за { get; set; } //Свойство 'Записано_за', которое используется для хранения информации о том, кем была была взята книга
        public override string ToString() //Переопределение метода ToString() для форматирования строки вывода
        {
            if (string.IsNullOrEmpty(Записано_за))  //Проверка, заполнено ли свойство 'Записано_за'. Если нет, возвращается базовая строка из родительского класса 'Книга'
            {
                return base.ToString();
            }
            else  //Если свойство 'Записано_за' заполнено, возвращается расширенная строка с дополнительной информацией о дате взятия/возврата книги
            {
                return base.ToString() + $" [Взята: {Записано_за}] Дата взятия/возврата: {DateTime.Now}.";
            }
        }
    }
}