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
                Console.Write("Wat Wilt u doen? \n1. Storting \n2. Afhalen");
                intKeuze = Convert.ToInt32(Console.ReadLine());
                if (intKeuze == 1)
                {
                    Storting(rekening);
                }
                else
                {
                    Afhalen(rekening);
                }
                
               
                Console.WriteLine("Wilt u nog een transactie uitvoeren? ");
                strAnswer = Console.ReadLine().ToUpper();
            } while (strAnswer == "Y");
        }

        private static void Afhalen(bankrekening rekening)
        {
            
        }

        private static void Storting(bankrekening rekening)
        {
            
        }

        private static void Gegevens(bankrekening rekening)
        {
            Console.WriteLine($"Er staat {rekening.RStand} Euro op uw rekening.");
            Console.WriteLine($"U mag {rekening.Limiet} Euro onder 0 gaan.");
            Console.WriteLine($"U heeft {rekening.Verrichting} transacties gedaan.");
            Console.ReadLine();
        }

        private static void LimietSet(bankrekening rekening)
        {
            rekening.Limiet = -1000;
        }
    }
}
