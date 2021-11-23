using System.Numerics;
using IBAN_C;
using EAN_C;
using ISBN_C;
using ISIN_C;

namespace IBAN_Rechner
{
    public class Pruefziffer_Josua
    {

        public static void Main(string[] args)
        {


            


            bool fenster = true; //für mehrfaches eingeben von Werten/ Überprüfungen
            while (fenster == true)
            {
                Console.Title = "Prüffziffern Rechner";
                string[] ABC_E2 /* Ersetzen (für ISIN) */ = { "1 0", "1 1", "1 2", "1 3", "1 4", "1 5", "1 6", "1 7", "1 8", "1 9", "2 0", "2 1", "2 2", "2 3", "2 4", "2 5", "2 6", "2 7", "2 8", "2 9", "3 0", "3 1", "3 2", "3 3", "3 4", "3 5" };
                string[] ABC_E /* Ersetzen */ = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35" };
                string[] ABC = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

                Console.WriteLine("Welches Format möchten sie überprüfen?");
                Console.WriteLine("IBAN, ISBN, ISIN oder EAN?");
                Console.ForegroundColor = ConsoleColor.Blue;
                string? Format = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (Format != null)
                {
                    for (int i = 0; i < ABC.Length; i++)
                    {
                        Format = Format.Replace(ABC[i], ABC_E[i]);
                    }
                    int Format_I /* Format Int */ = int.Parse(Format);
                    /* Credits: @Joscupe & @JanSirProXx*/
                    IBAN iban = new IBAN();
                    ISBN isbn = new ISBN();
                    ISIN isin = new ISIN();
                    EAN ean = new EAN();
                    if (Format_I == 18111023) //IBAN
                    {
                        iban.IBAN_M();


                    }
                    else if (Format_I == 18281123) //ISBN
                    {
                        isbn.ISBN_M();
                    } /* Credits Joscupe */
                    else if (Format_I == 18281823) //ISIN
                    {
                        isin.ISIN_M();
                    }
                    else if (Format_I == 141023) //EAN
                    {
                        ean.EAN_M();
                    }
                    Console.WriteLine("Möchten Sie noch eine Überprüfung durchführen? (y/n)");
                    string? wiederholung = Console.ReadLine();
                    if (wiederholung != "y")
                    {
                        fenster = false;
                    }
                } else
                {
                    Console.WriteLine("Geben Sie bitte einen Wert ein");
                }
            }
        }
    }
} /* Credits Joscupe */
