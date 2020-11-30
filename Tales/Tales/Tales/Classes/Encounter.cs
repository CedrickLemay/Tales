using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public class Encounter
    {
        
        private int adjective;
        private int reactionTable;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ReactionTable
        {
            get { return reactionTable; }
            set { reactionTable = value; }
        }


        public int Adjective
        {
            get { return adjective; }
            set { adjective = value; }
        }


        public Encounter(int a, string n,  int rt)
        {
            this.Adjective = a;
            this.Name = n;
            this.ReactionTable = rt;
        }
        
    }


}
