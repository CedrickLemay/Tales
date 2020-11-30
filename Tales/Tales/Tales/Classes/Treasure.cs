using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{

    class Treasure
    {
        private int sellback_value;
        private Wealth max_wealth;
        private string effect;
        private string description;

        public Treasure(int sbv, Wealth w, string e, string d)
        {
            sellback_value = sbv;
            max_wealth = w;
            effect = e;
            description = d;
        }

        public void sell(Player p)
        {
            p.PlayerWealth.WealthValue += sellback_value;

            if (p.PlayerWealth.WealthValue > max_wealth.WealthValue)
                p.PlayerWealth = max_wealth;            
        }
        
    }

}
