using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public sealed class Reaction_Matrix
    {
        //http://www.csharp-examples.net/list/
        private static List<string>[] reac_list;

        private static Reaction_Matrix instance = null;
        private static readonly object padlock = new object();

        private Reaction_Matrix()
        {
            int reac_table;
            int reac_amount;
            string[] line_content;
 
            string[] lines = System.IO.File.ReadAllLines("Reaction_Matrix.txt");

            reac_list = new List<string>[lines.Length];            

            for (int i = 0; i < lines.Length; i++)  //COMMENT THIS
            {
                reac_list[i] = new List<string>();

                line_content = lines[i].Split(';');
                reac_table = Program.getReactionID(line_content[0][0]);
                reac_amount = Int32.Parse(line_content[1]);

                for (int j = 0; j < reac_amount; j++)
                {
                    reac_list[i].Add(line_content[j+2]);
                }
            }            
        }

        public static Reaction_Matrix Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Reaction_Matrix();
                    }
                    return instance;
                }
            }
        }

        public string getReactionText(char reac_table, int reac_ID)
        {
            return reac_list[Program.getReactionID(Char.ToUpper(reac_table))].ElementAt(reac_ID);
        }

        public string getReactionText(int reac_table, int reac_ID)
        {
            return reac_list[reac_table].ElementAt(reac_ID);
        }

        public int getReactionID(char reac_table, string reac_text)
        {
            return reac_list[Program.getReactionID(reac_table)].FindIndex(x => x == reac_text);
        }

        public int getReactionID(int reac_table, string reac_text)
        {
            return reac_list[reac_table].FindIndex(x => x == reac_text);
        }

        public int getReactionTableSize(char reac_table)
        {
            
            return reac_list[Program.getReactionID(Char.ToUpper(reac_table))].Count();
        }

        public int getReactionTableSize(int reac_table)
        {
            return reac_list[reac_table].Count();
        }
    }
}
