﻿using System;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using TestSolution.Properties;

namespace Lab_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What do you want from me?\nEnter the age, height, name and lastname: ");
            var age = Convert.ToInt32(Console.ReadLine());
            var height = Convert.ToInt32(Console.ReadLine());
            var name = Console.ReadLine();
            var lastName = Console.ReadLine();
            string university;
            int year;
            var formOfStudy = false;
            string facInput;
            Console.WriteLine($"Учится ли {name} {lastName} в каком-либо университете?\nДа/Нет: ");
            var answer = Console.ReadLine();
            if (answer == "Да" || answer == "да")
            {
                Console.WriteLine("Ввудите университет, курс, форму обучения и название факультета: ");
                university = Console.ReadLine();
                year = Convert.ToInt32(Console.ReadLine());
                var formOfStudyinput = Console.ReadLine();
                formOfStudy = formOfStudyinput == "платная" || formOfStudyinput == "Платная";
                facInput = Console.ReadLine();
            }
            else
            {
                university = "Не учится";
                year = 0;
                facInput = "Нет";
            }

            Console.WriteLine("Введите пол: ");
            var sexInput = Console.ReadLine();

            Sex sex;

            if (sexInput == "Мужчина" || sexInput == "мужчина")
                sex = Sex.Male;
            else
                sex = Sex.Female;

            //Student man = new Student(age, height, name, lastName, university, year, formOfStudy, sex);
            IPerson man = new SpecialKid(age, height, name, lastName, university, year, facInput, formOfStudy, sex);

            man.PrintInfo();

            Console.WriteLine(man.ArmyOrNot()
                ? $"{lastName} {name} годен к несению воинской службы! Ура!"
                : $"{lastName} {name} не будет служить в бравых войсках белорусской армии! Какая досада!");

            //Студент, который был создан просто для демонстрации работы IComparable(IComparable как стандартный интерфейс тут выступает)
            IPerson manForIComparable = new SpecialKid(19, 178, "Валера", "Вазектамин", "БГУ", 2, "ФПМИ", false, Sex.Male);

            IPerson[] people = new IPerson[] { man, manForIComparable };
            Array.Sort(people);                                                //Сортируем объекты с помощью IComparable

            foreach (var p in people)                                  //Вывод информации о отсортированных студентах
            {
                p.PrintInfo();
            }

        }
    }
}