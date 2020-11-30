using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public class Encounter_Table
    {
        private int table_ID;
        private Encounter[] encounter_list;

        public Encounter_Table(int t_id, Encounter [] el)
        {
            if (el.Length != 12) return;

            table_ID = t_id;
            encounter_list = el;
        }

        public int getID()
        {
            return table_ID;
        }

        public Encounter getEncounter(int enc)
        {
            return encounter_list[enc-1];
        }


    }
}
