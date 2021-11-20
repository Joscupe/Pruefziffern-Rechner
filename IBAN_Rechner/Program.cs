using System;
using System.Collections.Generic;
using System.Linq;

namespace IBAN_Rechner
{
    public class Program
    {
        public static void Main(string[] args)
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
            string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for(int i = 0; i < ABC.Length; i++)
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
            if(IBAN_P == IBAN_B) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Die IBAN stimmt");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Die IBAN stimmt nicht");
            }
            Console.ForegroundColor = ConsoleColor.White;


        }
    }
}