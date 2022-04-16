using System;
using System.Collections.Generic;
using System.Text;

namespace classes_2._1
{
    class bankrekening
    {
        //Beschermde variabelen
        private int intrekeningstand;
        private int intlimiet;
        private int intverrichtingen;

        //Alle get set functies voor deze variabelen
        public int RStand
        {
            get { return intrekeningstand; }
            set { intrekeningstand = value; }
        }
        public int Limiet
        {
            get { return intlimiet; }
            set { intlimiet = value; }
        }
        public int Verrichting
        {
            get { return intverrichtingen; }
            set { intverrichtingen = value; }
        }

        //De constructor die alle variabelen op 0 zet ADHV de get/set functie
        public bankrekening()
        {
            RStand = 0;
            Limiet = 0;
            Verrichting = 0;
        }
    }
}
