using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ISIN_C
{
    internal class ISIN
    {
        string[] ABC_E2 /* Ersetzen (für ISIN) */ = { "1 0", "1 1", "1 2", "1 3", "1 4", "1 5", "1 6", "1 7", "1 8", "1 9", "2 0", "2 1", "2 2", "2 3", "2 4", "2 5", "2 6", "2 7", "2 8", "2 9", "3 0", "3 1", "3 2", "3 3", "3 4", "3 5" };
        string[] ABC_E /* Ersetzen */ = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35" };
        string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public void ISIN_M()
        {
            Console.Title = "ISIN Rechner";
            Console.WriteLine("Geben Sie bitte die ISIN an, im Format:");
            Console.WriteLine("X X Y Y Y Y Y Y Y Y Y Y");
            Console.ForegroundColor = ConsoleColor.Blue;
            string? ISIN = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < ABC.Length; i++)
            {
                ISIN = ISIN.Replace(ABC[i], ABC_E2[i]);
            }

            string[] ISIN_S = ISIN.Split(' ');
            int ISIN_P = int.Parse(ISIN_S[13]);
            int ISIN_I = ((int.Parse(ISIN_S[0]) * 2) % 10) + ((int.Parse(ISIN_S[0]) * 2) / 10) + int.Parse(ISIN_S[1]) + ((int.Parse(ISIN_S[2]) * 2) % 10) + ((int.Parse(ISIN_S[2]) * 2) / 10) + int.Parse(ISIN_S[3]) + ((int.Parse(ISIN_S[4]) * 2) % 10) + ((int.Parse(ISIN_S[4]) * 2) / 10) + int.Parse(ISIN_S[5]) + ((int.Parse(ISIN_S[6]) * 2) % 10) + ((int.Parse(ISIN_S[6]) * 2) / 10) + int.Parse(ISIN_S[7]) + ((int.Parse(ISIN_S[8]) * 2) % 10) + ((int.Parse(ISIN_S[8]) * 2) / 10) + int.Parse(ISIN_S[9]) + ((int.Parse(ISIN_S[10]) * 2) % 10) + ((int.Parse(ISIN_S[10]) * 2) / 10) + int.Parse(ISIN_S[11]) + ((int.Parse(ISIN_S[12]) * 2) % 10) + ((int.Parse(ISIN_S[12]) * 2) / 10);
            ISIN_I = 10 - (ISIN_I % 10);
            Console.WriteLine("Die eingegebene Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ISIN_P); //gibt die 'ausgerechnete' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Die berechnete Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ISIN_I); //gibt die 'tatsächliche' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Status:");
            if (ISIN_I == ISIN_P)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Die ISIN stimmt");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Die ISIN stimmt nicht");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
