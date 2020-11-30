using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    class Wealth
    {
        public const int WEALTH_BEGGAR = 0;
        public const int WEALTH_PENNILESS = 1;
        public const int WEALTH_POOR = 2;
        public const int WEALTH_RESPECTABLE = 3;
        public const int WEALTH_RICH = 4;
        public const int WEALTH_PRINCELY = 5;
        public const int WEALTH_FABULOUS = 6;

        private int wealth_value;

        public Wealth()
        {
            wealth_value = WEALTH_POOR;
        }

        public Wealth(int value)
        {
            wealth_value = value;
        }

        public int WealthValue
        {
            get { return wealth_value; }
            set { wealth_value = value; }
        }
        
        public int LandMouvement()
        {
            switch (wealth_value)
            {
                case WEALTH_BEGGAR:
                    return 3;
                    
                case WEALTH_PENNILESS:
                    return 3;
                    
                case WEALTH_POOR:
                    return 3;
                    
                case WEALTH_RESPECTABLE:
                    return 4;
                    
                case WEALTH_RICH:
                    return 4;
                    
                case WEALTH_PRINCELY:
                    return 3;
                    
                case WEALTH_FABULOUS:
                    return 3;
                    
                default:
                    return -1;
                    
            }

        }

        public int SeaMouvement()
        {
            switch (wealth_value)
            {
                case WEALTH_BEGGAR:
                    return 2;

                case WEALTH_PENNILESS:
                    return 2;

                case WEALTH_POOR:
                    return 2;

                case WEALTH_RESPECTABLE:
                    return 4;

                case WEALTH_RICH:
                    return 4;

                case WEALTH_PRINCELY:
                    return 5;

                case WEALTH_FABULOUS:
                    return 6;

                default:
                    return -1;

            }

        }

        public string getWealthName()
        {
            switch (wealth_value)
            {
                case WEALTH_BEGGAR:
                    return "Beggar";

                case WEALTH_PENNILESS:
                    return "Penniless";

                case WEALTH_POOR:
                    return "Poor";

                case WEALTH_RESPECTABLE:
                    return "Respectable";

                case WEALTH_RICH:
                    return "Rich";

                case WEALTH_PRINCELY:
                    return "Pricely";

                case WEALTH_FABULOUS:
                    return "Fabulous";

                default:
                    return "None";

            }

        }

        public static Wealth operator+ (Wealth w, int val)
        {
            Wealth newWealth = new Wealth
            {
                WealthValue = w.WealthValue + val
            };

            return newWealth;
        }


    }

    
}
