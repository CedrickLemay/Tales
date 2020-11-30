using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public sealed class Encounter_Matrix
    {
        private static List<Encounter_Table> encounter_table_list;

        private static Encounter_Matrix instance = null;
        private static readonly object padlock = new object();

        private Encounter_Matrix()
        {
            string[] line_content;
            int encounter_table;
            int encounter_number;
            int reaction_table_ID;
            int adjective_ID;
            string name;
            Encounter[] table;

            string[] lines = System.IO.File.ReadAllLines("Encounter_Matrix.txt");

            encounter_table_list = new List<Encounter_Table>();
            
            for (int i = 0; i < lines.Length; i+=12)
            {
                table = new Encounter[12];

                // I do those two step so we don't have to do the second one each
                // time we go throught the second loop.
                line_content = lines[i].Split(';');
                encounter_table = Int32.Parse(line_content[0]);
  
                for (int j = 0; j < 12; j++)
                {
                    line_content = lines[i + j].Split(';');
                    reaction_table_ID = Program.getReactionID(line_content[1][0]); // need [0] because it is a string
                    encounter_number = Int32.Parse(line_content[2]);
                    adjective_ID = Adjective_Matrix.Instance.getAdjectiveID(reaction_table_ID, line_content[3]);
                    name = line_content[4];
                    table[j] = new Encounter(adjective_ID, name, reaction_table_ID);
                }

                encounter_table_list.Add(new Encounter_Table(encounter_table, table));
            }
    
        }

        public static Encounter_Matrix Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Encounter_Matrix();
                    }
                    return instance;
                }
            }
        }

        public Encounter getEncounter(int encounter_table, int encounter_num)
        {
            int  table_ID = encounter_table_list.FindIndex(x => x.getID() == encounter_table);

            return encounter_table_list[table_ID].getEncounter(encounter_num);            
        }

    }
}
