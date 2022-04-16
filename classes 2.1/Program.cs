using System;

namespace classes_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bankrekening rekening = new bankrekening();
            string strAnswer;
            int intKeuze;
            LimietSet(rekening);
            Gegevens(rekening);
            do
            {
                Console.WriteLine("Wat Wilt u doen? \n1. Storting \n2. Afhalen");
                intKeuze = Convert.ToInt32(Console.ReadLine());
                if (intKeuze == 1)
                {
                    Storting(rekening);
                    Console.Clear();
                }
                else
                {
                    Afhalen(rekening);
                    Console.Clear();
                }
                rekening.Verrichting++;

                Gegevens(rekening);
               
                Console.WriteLine("Wilt u nog een transactie uitvoeren? ");
                strAnswer = Console.ReadLine().ToUpper();
            } while (strAnswer == "Y");
        }

        private static void Afhalen(bankrekening rekening)
        {
            Console.Clear();
            Gegevens(rekening);
            int intAfhaal;
            Console.Write("Geef een bedrag dat u wilt afhalen: ");
            intAfhaal = Convert.ToInt32(Console.ReadLine());
            if (rekening.RStand - intAfhaal < rekening.Limiet)
            {
                Console.WriteLine("U kunt niet zover onder 0 gaan.");
                Console.WriteLine($"De limiet is {rekening.Limiet}");
                transactie(rekening, intAfhaal, "A");
                Afhalen(rekening);
            }
            else
            {              
                Console.WriteLine("Transactie succesvol!");
                transactie(rekening, intAfhaal, "A");
                rekening.RStand -= intAfhaal;
            }
        }

        private static void transactie(bankrekening rekening, int intbedrag, string strType)
        {
            if (strType == "A")
            {
                Console.WriteLine($"{rekening.RStand} - {intbedrag} = {rekening.RStand - intbedrag}");
            }
            else if(strType == "S")
            {
                Console.WriteLine($"{rekening.RStand} + {intbedrag} = {rekening.RStand + intbedrag}");
            }
            Console.ReadLine();
        }

        private static void Storting(bankrekening rekening)
        {
            Console.Clear();
            Gegevens(rekening);
            int intStorting;
            Console.Write("Geef een bedrag dat u wilt storten: ");
            intStorting = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Transactie succesvol!");
            transactie(rekening, intStorting, "S");
            rekening.RStand += intStorting;
        }

        private static void Gegevens(bankrekening rekening)
        {
            Console.WriteLine($"Er staat {rekening.RStand} Euro op uw rekening.");
            Console.WriteLine($"U mag {rekening.Limiet} Euro onder 0 gaan.");
            Console.WriteLine($"U heeft {rekening.Verrichting} transacties gedaan.\n");
        }

        private static void LimietSet(bankrekening rekening)
        {
            rekening.Limiet = -1000;
        }
    }
}
