using System;
using System.Globalization;

namespace Лаба_2__1_
{
    class Task_1
    {

        public static void Main(string[] args)
        {
            for (int a = 1; a <= 12; a++)
            {
                DateTime dateTime = new DateTime(1, a, 1);
                Console.WriteLine(dateTime.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
            }
        }
    }
}
