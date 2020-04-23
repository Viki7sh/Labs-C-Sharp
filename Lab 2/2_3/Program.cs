using System;

namespace Лаба_2__2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyz";
            int letter;
            string res;

            for (int i=1; i<=4; i++)
            {
                letter = rnd.Next(0, 26);
                res = String.Concat(letters[letter]);
                Console.Write(res);
            }
        }
    }
}
