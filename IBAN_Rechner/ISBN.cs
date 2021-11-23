using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ISBN_C
{
    internal class ISBN
    {
        string[] ABC_E2 /* Ersetzen (für ISIN) */ = { "1 0", "1 1", "1 2", "1 3", "1 4", "1 5", "1 6", "1 7", "1 8", "1 9", "2 0", "2 1", "2 2", "2 3", "2 4", "2 5", "2 6", "2 7", "2 8", "2 9", "3 0", "3 1", "3 2", "3 3", "3 4", "3 5" };
        string[] ABC_E /* Ersetzen */ = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35" };
        string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public void ISBN_M()
        {
            Console.Title = "ISBN Rechner";
            Console.WriteLine("Geben Sie bitte die ISBN an, im Format:");
            Console.WriteLine("Y Y Y Y Y Y Y Y Y Y Y Y Y");
            Console.ForegroundColor = ConsoleColor.Blue;
            string? ISBN = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            string[] ISBN_S = ISBN.Split(' ');
            int ISBN_P = int.Parse(ISBN_S[12]);
            int ISBN_I = int.Parse(ISBN_S[0]) * 1 + int.Parse(ISBN_S[1]) * 3 + int.Parse(ISBN_S[2]) * 1 + int.Parse(ISBN_S[3]) * 3 + int.Parse(ISBN_S[4]) * 1 + int.Parse(ISBN_S[5]) * 3 + int.Parse(ISBN_S[6]) * 1 + int.Parse(ISBN_S[7]) * 3 + int.Parse(ISBN_S[8]) * 1 + int.Parse(ISBN_S[9]) * 3 + int.Parse(ISBN_S[10]) * 1 + int.Parse(ISBN_S[11]) * 3;
            ISBN_I = (((ISBN_I / 10) + 1) * 10) - ISBN_I;
            Console.WriteLine("Die eingegebene Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ISBN_P); //gibt die 'ausgerechnete' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Die berechnete Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ISBN_I); //gibt die 'tatsächliche' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Status:");
            if (ISBN_I == ISBN_P)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Die ISBN stimmt");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Die ISBN stimmt nicht");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
