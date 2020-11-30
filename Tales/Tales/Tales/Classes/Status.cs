using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public class Status
    {
        public const int NUMBER_OF_STATUS = 28;

        public const int STATUS_ACCURSED = 0;
        public const int STATUS_BEAST_FORM = 1;
        public const int STATUS_BELOVED = 2;
        public const int STATUS_BLESSED = 3;
        public const int STATUS_CRIPPLED = 4;
        public const int STATUS_DETERMINED = 5;
        public const int STATUS_DISEASED = 6;
        public const int STATUS_ENSLAVED = 7;
        public const int STATUS_ENSORCELLED = 8;

        public const int STATUS_ENVIOUS = 9;
        public const int STATUS_FATED = 10;
        public const int STATUS_GRIEF_STRIKEN = 11;
        public const int STATUS_IMPRISONED = 12;
        public const int STATUS_INSANE = 13;
        public const int STATUS_LOST = 14;
        public const int STATUS_LOVE_STRUCK = 15;

        public const int STATUS_MARRIED = 16;
        public const int STATUS_ON_PILGRIMAGE = 17;
        public const int STATUS_OUTLAW = 18;
        public const int STATUS_PURSUED = 19;

        public const int STATUS_RESPECTED = 20;
        public const int STATUS_ROBE_OF_HONOR = 21;
        public const int STATUS_SCORNED = 22;
        public const int STATUS_SEX_CHANGED = 23;
        public const int STATUS_SULTAN = 24;
        public const int STATUS_UNDER_GEAS = 25;
        public const int STATUS_VIZIER = 26;
        public const int STATUS_WOUNDED = 27;


        private bool has_Status = false;

        public bool HasStatus
        {
            get { return has_Status; }
            set { has_Status = value; }
        }



        /*
         *
         *      Get Name: Get the name of the status.
         * 
         */

        static public string GetName(int s)
        {
            switch(s)
            {
                case STATUS_ACCURSED:
                    return "Accursed";
                case STATUS_BEAST_FORM:
                    return "Beast Form";
                case STATUS_BELOVED:
                    return "Beloved";
                case STATUS_BLESSED:
                    return "Blessed";
                case STATUS_CRIPPLED:
                    return "Crippled";
                case STATUS_DETERMINED:
                    return "Determined";
                case STATUS_DISEASED:
                    return "Diseased";
                case STATUS_ENSLAVED:
                    return "Enslaved";
                case STATUS_ENSORCELLED:
                    return "Ensorcelled";
                case STATUS_ENVIOUS:
                    return "Envious";
                case STATUS_FATED:
                    return "Fated";
                case STATUS_GRIEF_STRIKEN:
                    return "Grief Striken";
                case STATUS_IMPRISONED:
                    return "Imprisoned";
                case STATUS_INSANE:
                    return "Insane";
                case STATUS_LOST:
                    return "Lost";
                case STATUS_LOVE_STRUCK:
                    return "Love Struck";
                case STATUS_MARRIED:
                    return "Married";
                case STATUS_ON_PILGRIMAGE:
                    return "On Pilgrimage";
                case STATUS_OUTLAW:
                    return "Outlaw";
                case STATUS_PURSUED:
                    return "Pursued";
                case STATUS_RESPECTED:
                    return "Respected";
                case STATUS_ROBE_OF_HONOR:
                    return "Robe Of Honor";
                case STATUS_SCORNED:
                    return "Scorned";
                case STATUS_SEX_CHANGED:
                    return "Sex-Changed";
                case STATUS_SULTAN:
                    return "Sultant";
                case STATUS_UNDER_GEAS:
                    return "Under Geas";
                case STATUS_VIZIER:
                    return "Vizier";
                case STATUS_WOUNDED:
                    return "Wounded";
                default:
                    return null;

            }
        }


        
    }
}
