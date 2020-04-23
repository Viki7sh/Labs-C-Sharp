using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_1
{
    class LaunchGame
    {
        public static void Manage()
        {
            int finishGame, menuTracker; // finishGame - Метка для закрытия игры; menuTracker - Метка, для выхода в меню
            do
            {
                finishGame = 0;
                menuTracker = 0;
                ConsoleKeyInfo externalMenu, internalMenu; // externalMenu - ввод в главном меню; internalMenu - ввод в побочном меню
                Console.Clear();
                do
                {
                    MessageDisplayment.Name();
                    MessageDisplayment.Menu();
                    externalMenu = Console.ReadKey();
                    Console.Clear();
                    /* D1 - клавиша "1", D2 - клавиша "2" и так далее */
                    switch (externalMenu.Key.ToString())
                    {
                        // while (startGame == 1) {
                        case "D1":
                            Game();
                            break;

                        case "D2":
                            // Пока пользователь не кликнет по нужной клавише, интерфейс будет оставаться прежним
                            do
                            {
                                Console.Clear();
                                MessageDisplayment.Name();
                                MessageDisplayment.Specification();
                                MessageDisplayment.BackToMenu();
                                internalMenu = Console.ReadKey();
                            } while (internalMenu.Key.ToString() != "D1");
                            menuTracker = 1;
                            break;

                        case "D0":
                            Console.Clear();
                            MessageDisplayment.Name();
                            MessageDisplayment.Exit();
                            finishGame = 1;
                            menuTracker = 1;
                            break;
                    }
                } while (menuTracker == 0);
            } while (finishGame == 0);
            Environment.Exit(0);
        }

        public static void Game()
        {
            ConsoleKeyInfo gameClick, internalMenu; // Нажатие клавиши в игре
            Random rnd = new Random(); // Переменная для генерации случайных чисел
            bool isClicked; // Проверка нажатия клавиши
            int counter = 0; // Счетчик кол-ва заполненных ячеек матрицы
            bool gameStart = true; // Проверка стадии игры
            bool finish = false; // Флажок, проверяющий окончание игры
            bool checkEmpty; // Флажок, проверяющий заполнение пустой ячейки матрицы
            int tempI, tempJ; // Переменные, для генерации случайной ячейки матрицы
            string[,] gameArray = new string[4, 4]; // Главная матрица
            bool[,] tempArray = new bool[4, 4];
            int tempSumm;
            int score = 0;
            bool gameFinish = false;
            int flag;

            // Обнуление матриц
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    gameArray[i, j] = " ";
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    tempArray[i, j] = false;

            // Пока игра не закончена, цикл не прекращается
            while (!finish)
            {
                if (gameStart && counter != 16)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        // Поиск пустой ячейки матрицы и записывание в нее 2
                        do
                        {
                            checkEmpty = false;
                            tempI = rnd.Next(0, 4);
                            tempJ = rnd.Next(0, 4);
                            if (gameArray[tempI, tempJ] == " ")
                            {
                                gameArray[tempI, tempJ] = "2";
                                checkEmpty = true;
                            }
                        } while (!checkEmpty);
                    }
                    gameStart = false;
                }
                else if (counter != 16)
                {
                    // Поиск пустой ячейки матрицы и записывание в нее 2
                    do
                    {
                        checkEmpty = false;
                        tempI = rnd.Next(0, 4);
                        tempJ = rnd.Next(0, 4);
                        if (gameArray[tempI, tempJ] == " ")
                        {
                            gameArray[tempI, tempJ] = "2";
                            checkEmpty = true;
                        }
                    } while (!checkEmpty);
                }
                counter = 0;

                // Вывод матрицы
                ShowArray(ref gameArray);

                // Нажатие кнопки пользователем
                // Если игра не окончена
                if (gameFinish == false)
                {
                    isClicked = false;
                    do
                    {
                        // Допустим ввод клавиш вниз, вверх, влево, вправо и "1"
                        Console.Write("\nСчет: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(score);
                        Console.ForegroundColor = ConsoleColor.White;
                        MessageDisplayment.BackToMenu();
                        gameClick = Console.ReadKey();
                        switch (gameClick.Key.ToString())
                        {
                            case "UpArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 3; i > 0; i--)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[i - 1, j] == " ")
                                            {
                                                gameArray[i - 1, j] = gameArray[i, j];
                                                gameArray[i, j] = " ";
                                            }
                                            if (gameArray[i - 1, j] == gameArray[i, j] && gameArray[i, j] != " " && tempArray[i, j] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[i - 1, j]) + int.Parse(gameArray[i, j]);
                                                gameArray[i - 1, j] = Convert.ToString(tempSumm);
                                                gameArray[i, j] = " ";
                                                score = ScoreCounter(score, gameArray[i - 1, j]);
                                                tempArray[i - 1, j] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "DownArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[i + 1, j] == " ")
                                            {
                                                gameArray[i + 1, j] = gameArray[i, j];
                                                gameArray[i, j] = " ";
                                            }
                                            if (gameArray[i + 1, j] == gameArray[i, j] && gameArray[i, j] != " " && tempArray[i, j] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[i + 1, j]) + int.Parse(gameArray[i, j]);
                                                gameArray[i + 1, j] = Convert.ToString(tempSumm);
                                                gameArray[i, j] = " ";
                                                score = ScoreCounter(score, gameArray[i + 1, j]);
                                                tempArray[i + 1, j] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "LeftArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 3; i > 0; i--)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[j, i - 1] == " ")
                                            {
                                                gameArray[j, i - 1] = gameArray[j, i];
                                                gameArray[j, i] = " ";
                                            }
                                            if (gameArray[j, i - 1] == gameArray[j, i] && gameArray[j, i] != " " && tempArray[j, i] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[j, i - 1]) + int.Parse(gameArray[j, i]);
                                                gameArray[j, i - 1] = Convert.ToString(tempSumm);
                                                gameArray[j, i] = " ";
                                                score = ScoreCounter(score, gameArray[j, i - 1]);
                                                tempArray[j, i - 1] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "RightArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[j, i + 1] == " ")
                                            {
                                                gameArray[j, i + 1] = gameArray[j, i];
                                                gameArray[j, i] = " ";
                                            }
                                            if (gameArray[j, i + 1] == gameArray[j, i] && gameArray[j, i] != " " && tempArray[j, i] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[j, i + 1]) + int.Parse(gameArray[j, i]);
                                                gameArray[j, i + 1] = Convert.ToString(tempSumm);
                                                gameArray[j, i] = " ";
                                                score = ScoreCounter(score, gameArray[j, i + 1]);
                                                tempArray[j, i + 1] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "D1":
                                Manage();
                                break;
                            default:
                                ShowArray(ref gameArray);
                                break;
                        }
                    } while (!isClicked);

                    // Если матрица заполнена, заканчиваем игру
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            if (gameArray[i, j] != " ")
                                counter++;

                    // Если матрица полностью заполнена, но есть ячейки, которые могут слиться
                    flag = 0;
                    if (counter == 16)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                                if (i == 3)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j + 1] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                                if (i == 1 || i == 2)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                            }
                        if (flag == 0)
                            gameFinish = true;
                        else
                            gameFinish = false;
                    }
                }
                // Если игра окончена
                if (gameFinish == true)
                {
                    // Пока пользователь не кликнет по нужной клавише, интерфейс будет оставаться прежним
                    do
                    {
                        ShowArray(ref gameArray);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nИгра завершена!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Cчет: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(score);
                        Console.ForegroundColor = ConsoleColor.White;
                        MessageDisplayment.BackToMenu();
                        MessageDisplayment.StartAgain();
                        internalMenu = Console.ReadKey();
                        if (internalMenu.Key.ToString() == "D1")
                            Manage();
                        if (internalMenu.Key.ToString() == "D2")
                            Game();
                        Console.Clear();
                    } while (internalMenu.Key.ToString() != "D1" && internalMenu.Key.ToString() != "D2");
                }

                if (gameFinish == true)
                    finish = true;
            }
        }

        public static int ScoreCounter(int x, string y)
        {
            x += int.Parse(y);
            return x;
        }

        public static void ShowArray(ref string[,] gameArray)
        {
            // Вывод матрицы
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    Console.WriteLine("–––––––––––––––––");
                Console.Write("| ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(gameArray[i, j] + " | ");
                }
                Console.WriteLine("\n–––––––––––––––––");
            }
        }
    }
}

