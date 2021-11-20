using System;
using System.Collections.Generic;
using System.Linq;

namespace IBAN_Rechner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie bitte die IBAN ein, im Format von:");
            Console.WriteLine("XXYY YYYY YYYY YYYY YYYY Y");
            string IBAN = Console.ReadLine();
            Console.WriteLine(IBAN);

            string[] IBAN_S = IBAN.Split(' '); //IBAN gesplitet
            String IBAN_U = IBAN_S[1] + IBAN_S[2] + IBAN_S[3] + IBAN_S[4] + IBAN_S[5] + IBAN_S[0]; //IBAN umgeschrieben
            Console.WriteLine(IBAN_U);
            string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] ABC_E /* Ersetzen */ = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
            for(int i = 0; i < ABC.Length; i++)
            {
                string[] IBAN_E = IBAN_U.Replace(ABC[i], ABC_E[i]);
            }

            

        }
    }
}