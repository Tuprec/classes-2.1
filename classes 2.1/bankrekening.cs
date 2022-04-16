using System;
using System.Collections.Generic;
using System.Text;

namespace classes_2._1
{
    class bankrekening
    {
        private int intrekeningstand;
        private int intlimiet;
        private int intverrichtingen;

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
        public bankrekening()
        {
            RStand = 0;
            Limiet = 0;
            Verrichting = 0;
        }
    }
}
