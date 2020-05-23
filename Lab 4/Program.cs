﻿using System;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace Lab_4
{
    class Program
    {
        //Тут лежит подсчёт факториала на с++
        [DllImport("D:\\Visual StudioDll\\C#\\Lab 4\\Dll.dll", CallingConvention = CallingConvention.Cdecl)]


        //Функция подсчёта факториала на с++
        public static extern int Fact(int n);


        //А ниже идут всякие приколы из C# для вычисления памяти и занятости цп
        public static string getCurrentCpuUsage(PerformanceCounter cpuCounter)       
        {
            return cpuCounter.NextValue() + "%";
        }

        public static string getAvailableRAM(PerformanceCounter ramCounter)
        {
            return ramCounter.NextValue() + "MB";
        }

        public static void Main(string[] args)
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            int i = 0;
            while (i < 10)
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                getCurrentCpuUsage(cpuCounter);
                System.Threading.Thread.Sleep(500);
                Console.WriteLine(getCurrentCpuUsage(cpuCounter) + " <-CPU");
                Console.WriteLine(getAvailableRAM(ramCounter) + " <-RAM");
                System.Threading.Thread.Sleep(1000);
                i++;
            }

            Console.WriteLine("А сейчас введите число, которое мы возведём в факториал: ");
            int a = Int32.Parse(Console.ReadLine());
            int c = Fact(a);
            Console.WriteLine($"Ответ равен {c}");
        }
    }
}