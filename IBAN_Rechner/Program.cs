using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IBAN_Rechner
{
    public class Program
    {

        public static void Main(string[] args)
        {
            string[] ABC_E2 /* Ersetzen (für ISIN) */ = { "1 0", "1 1", "1 2", "1 3", "1 4", "1 5", "1 6", "1 7", "1 8", "1 9", "2 0", "2 1", "2 2", "2 3", "2 4", "2 5", "2 6", "2 7", "2 8", "2 9", "3 0", "3 1", "3 2", "3 3", "3 4", "3 5" };
            string[] ABC_E /* Ersetzen */ = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35" };
            string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Console.WriteLine("Welches Format möchten sie überprüfen?");
            Console.WriteLine("IBAN, ISBN, ISIN oder EAN?");
            Console.ForegroundColor = ConsoleColor.Blue;
            string Format = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < ABC.Length; i++)
            {
                Format = Format.Replace(ABC[i], ABC_E[i]);
            }
            int Format_I /* Format Int */ = int.Parse(Format);


            if (Format_I == 18111023) //IBAN
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
            else if( Format_I == 18281123) //ISBN
            {
                Console.WriteLine("Geben Sie bitte die ISBN an, im Format:");
                Console.WriteLine("Y Y Y Y Y Y Y Y Y Y Y Y Y");
                Console.ForegroundColor = ConsoleColor.Blue;
                string ISBN = Console.ReadLine();
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
            else if (Format_I == 18281823) //ISIN
            {
                Console.WriteLine("Geben Sie bitte die ISIN an, im Format:");
                Console.WriteLine("X X Y Y Y Y Y Y Y Y Y Y");
                Console.ForegroundColor = ConsoleColor.Blue;
                string ISIN = Console.ReadLine();
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
            else if (Format_I == 141023) //EAN
            {
                Console.WriteLine("Geben Sie bitte die EAN an, im Format:");
                Console.WriteLine("Y Y Y Y Y Y Y Y Y Y Y Y Y");
                Console.ForegroundColor = ConsoleColor.Blue;
                string EAN = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                string[] EAN_S = EAN.Split(' ');
                int EAN_P = int.Parse(EAN_S[12]);
                int EAN_I = int.Parse(EAN_S[0]) * 1 + int.Parse(EAN_S[1]) * 3 + int.Parse(EAN_S[2]) * 1 + int.Parse(EAN_S[3]) * 3 + int.Parse(EAN_S[4]) * 1 + int.Parse(EAN_S[5]) * 3 + int.Parse(EAN_S[6]) * 1 + int.Parse(EAN_S[7]) * 3 + int.Parse(EAN_S[8]) * 1 + int.Parse(EAN_S[9]) * 3 + int.Parse(EAN_S[10]) * 1 + int.Parse(EAN_S[11]) * 3;
                EAN_I = (((EAN_I / 10) + 1) * 10) - EAN_I;
                Console.WriteLine("Die eingegebene Prüfziffer lautet:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(EAN_P); //gibt die 'ausgerechnete' Prüfziffer aus
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Die berechnete Prüfziffer lautet:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(EAN_I); //gibt die 'tatsächliche' Prüfziffer aus
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Status:");
                if (EAN_I == EAN_P)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Die EAN stimmt");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Die EAN stimmt nicht");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
