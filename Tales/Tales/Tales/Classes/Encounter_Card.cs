using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    abstract class Encounter_Card
    {
        public const int TYPE_TERRAIN = 0;
        public const int TYPE_CHARACTER = 1;
        public const int TYPE_CITY = 2;

        protected int type;
        protected string name;
        protected List<int> encouter_List;



        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public Encounter_Card(string n, int[] enc)
        {
            name = n;
            encouter_List = new List<int>(enc.Length);
          
            foreach (int e in enc)
            {
                encouter_List.Add(e);
            }
        }
        
        public int EncounterTable(Spaces s)
        {
            return encouter_List[s.Type];
        }

        public int EncounterTable(int a)
        {
            return encouter_List[a];
        }
    }

    class Terrain_Encounter : Encounter_Card
    {
        public Terrain_Encounter(string n, int[] enc) : base(n, enc)
        {
            type = Encounter_Card.TYPE_TERRAIN;
        }
    }

    class Character_Encounter : Encounter_Card
    {
        public Character_Encounter(string n, int[] enc) : base(n, enc)
        {
            type = Encounter_Card.TYPE_CHARACTER;
        }
    }

    class City_Encounter : Encounter_Card
    {
        private City_Card_Reward[] rewards;

        public City_Card_Reward[] Rewards
        {
            get { return rewards; }
            set { rewards = value; }
        }

        public City_Encounter(string n, int[] enc, City_Card_Reward[] rew) : base(n, enc)
        {
            Rewards = rew;
            type = Encounter_Card.TYPE_CITY;
        }

    }
}
