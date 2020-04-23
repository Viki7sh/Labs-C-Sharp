using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_1
{
    class MessageDisplayment
    {
        public static void Name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   Игра 2048");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Menu()
        {
            Console.WriteLine("\n     Меню");
            Console.WriteLine("1. Начать игру" +
                              "\n2. Правила игры" +
                              "\n0. Закрыть приложение");

        }
        public static void Specification()
        {
            Console.WriteLine("\nНажатием стрелки вы можете скинуть все плитки игрового поля в одну из 4 сторон." +
                              "\nЕсли при скидывании две плитки одного номинала 'налетают' одна на другую, то они" +
                              "\nслипаются в одну, номинал которой равен сумме соединившихся плиток. После каждо-" +
                              "\nго хода на свободной секции поля появляется новая плитка номиналом «2» или «4». " +
                              "\nЕсли при нажатии кнопки местоположение плиток или их номинал не изменится, то " +
                              "\nход не совершается. Игра заканчивается поражением, если после очередного хода " +
                              "\nневозможно совершить действие");
        }

        public static void BackToMenu()
        {
            Console.WriteLine("\n1. Выйти в меню");
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗакрытие приложения...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void StartAgain()
        {
            Console.WriteLine("2. Начать игру заново");
        }
    }
}
