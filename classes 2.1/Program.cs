using System;

namespace classes_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variabelen declareren
            bankrekening rekening = new bankrekening();
            string strAnswer;
            int intKeuze;

            //Method voor de limiet onder 0 vast te zetten
            LimietSet(rekening);

            //Method voor de gegevens van de rekening te tonen
            Gegevens(rekening);

            //Do while functie voor alle gegevens en transacties te doen
            do
            {
                //Klein keuze menu om te kiezen voor storten of afhalen
                Console.WriteLine("Wat Wilt u doen? \n1. Storting \n2. Afhalen");
                intKeuze = Convert.ToInt32(Console.ReadLine());
                if (intKeuze == 1)
                {
                    //method voor storting
                    Storting(rekening);
                    Console.Clear();
                }
                else
                {
                    //Method voor afhaal
                    Afhalen(rekening);
                    Console.Clear();
                }

                //Aantal verrichtingen bijhouden
                rekening.Verrichting++;

                //Gegevens tonen
                Gegevens(rekening);
                
                //Vragen aan de gebruiker of ze nog een transactie wil uitvoeren
                Console.WriteLine("Wilt u nog een transactie uitvoeren? ");
                strAnswer = Console.ReadLine().ToUpper();
            } while (strAnswer == "Y");
        }

        //Method voor afhaal
        private static void Afhalen(bankrekening rekening)
        {
            //Console leegmaken van het keuze menu
            Console.Clear();

            //gegeven tonen
            Gegevens(rekening);

            //Variabele declareren
            int intAfhaal;

            //Het gewenste bedrag vragen aan de eindgebruiker
            Console.Write("Geef een bedrag dat u wilt afhalen: ");
            intAfhaal = Convert.ToInt32(Console.ReadLine());

            //Checken of het bedrag niet over het limiet gaat
            if (rekening.RStand - intAfhaal < rekening.Limiet)
            {
                //Zo ja dan toont het de transactie en de limiet opnieuw
                Console.WriteLine("U kunt niet zover onder 0 gaan.");
                Console.WriteLine($"De limiet is {rekening.Limiet}");

                //Method voor de transactie te tonen
                transactie(rekening, intAfhaal, "A");
                // de afhaal functie opnieuw oproepen voor een juist bedrag in te geven
                Afhalen(rekening);
            }
            else
            {            
                //Zo nee, is de transactie succesvol 
                Console.WriteLine("Transactie succesvol!");

                //Method voor de transactie te tonen
                transactie(rekening, intAfhaal, "A");

                //De rekenings variabele van de klasse updaten ADHV get/set functie
                rekening.RStand -= intAfhaal;
            }
        }

        //Method voor de transactie te tonen
        private static void transactie(bankrekening rekening, int intbedrag, string strType)
        {
            //het verschil tussen Storting (S) en Afhalen(A)
            if (strType == "A")
            {
                //Ingeval van afhalen
                Console.WriteLine($"{rekening.RStand} - {intbedrag} = {rekening.RStand - intbedrag}");
            }
            else if(strType == "S")
            {
                //Ingeval van storting
                Console.WriteLine($"{rekening.RStand} + {intbedrag} = {rekening.RStand + intbedrag}");
            }
            Console.ReadLine();
        }

        //Method voor de storting
        private static void Storting(bankrekening rekening)
        {
            //Console leegmaken van het keuze menu
            Console.Clear();

            //gegeven tonen
            Gegevens(rekening);
            //Variabelen declareren
            int intStorting;

            //Het gewenste bedrag vragen aan de eindgebruiker
            Console.Write("Geef een bedrag dat u wilt storten: ");
            intStorting = Convert.ToInt32(Console.ReadLine());

            //Zeggen dat de transactie succesvol was 
            Console.WriteLine("Transactie succesvol!");

            //De transactie tonen 
            transactie(rekening, intStorting, "S");

            //De rekenings variabele van de klasse updaten ADHV get/set functie
            rekening.RStand += intStorting;
        }

        //Method voor de gegevens van de rekening te tonen
        private static void Gegevens(bankrekening rekening)
        {
            Console.WriteLine($"Er staat {rekening.RStand} Euro op uw rekening.");
            Console.WriteLine($"U mag {rekening.Limiet} Euro onder 0 gaan.");
            Console.WriteLine($"U heeft {rekening.Verrichting} transacties gedaan.\n");
        }

        //Method voor de limiet onder 0 vast te zetten
        private static void LimietSet(bankrekening rekening)
        {
            rekening.Limiet = -1000;
        }
    }
}
