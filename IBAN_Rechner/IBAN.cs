using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace IBAN_C
{
    internal class IBAN
    {
        string[] ABC_E2 /* Ersetzen (für ISIN) */ = { "1 0", "1 1", "1 2", "1 3", "1 4", "1 5", "1 6", "1 7", "1 8", "1 9", "2 0", "2 1", "2 2", "2 3", "2 4", "2 5", "2 6", "2 7", "2 8", "2 9", "3 0", "3 1", "3 2", "3 3", "3 4", "3 5" };
        string[] ABC_E /* Ersetzen */ = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35" };
        string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public void IBAN_M()
        {

            Console.Title = "IBAN Rechner";
            Console.WriteLine("Geben Sie bitte die IBAN ein, im Format von:");
            Console.WriteLine("XX YY YYYY YYYY YYYY YYYY Y");
            Console.ForegroundColor = ConsoleColor.Blue;
            string IBAN = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            string[] IBAN_S = IBAN.Split(' '); //IBAN gesplitet
            int IBAN_P /* Prüfziffer */ = int.Parse(IBAN_S[1]);
            string IBAN_U = IBAN_S[2] + IBAN_S[3] + IBAN_S[4] + IBAN_S[5] + IBAN_S[6] + IBAN_S[0] + "00"; //IBAN umgeschrieben
            for (int i = 0; i < ABC.Length; i++)
            {
                IBAN_U = IBAN_U.Replace(ABC[i], ABC_E[i]);
            }
            BigInteger IBAN_B = BigInteger.Parse(IBAN_U);
            IBAN_B = IBAN_B % 97;
            IBAN_B = 98 - IBAN_B;
            Console.WriteLine("Die eingegebene Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(IBAN_P); //gibt die 'ausgerechnete' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Die berechnete Prüfziffer lautet:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(IBAN_B); //gibt die 'tatsächliche' Prüfziffer aus
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Status:");
            if (IBAN_P == IBAN_B)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Die IBAN stimmt");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Die IBAN stimmt nicht");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
