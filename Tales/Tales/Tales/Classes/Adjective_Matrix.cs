using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public sealed class Adjective_Matrix
    {

        //http://www.csharp-examples.net/list/
        private static List<string>[] adj_list;

        private static Adjective_Matrix instance = null;
        private static readonly object padlock = new object();

        private Adjective_Matrix()
        {
            int reac_table;
            int reac_amount;
            string[] line_content;

            string[] lines = System.IO.File.ReadAllLines("Adjective_Matrix.txt");

            adj_list = new List<string>[lines.Length];

            for (int i = 0; i < lines.Length; i++)  //COMMENT THIS
            {
                adj_list[i] = new List<string>();

                line_content = lines[i].Split(';');
                reac_table = Program.getReactionID(line_content[0][0]);
                reac_amount = Int32.Parse(line_content[1]);

                for (int j = 0; j < reac_amount; j++)
                {
                    adj_list[i].Add(line_content[j + 2]);
                }
            }
        }

        public static Adjective_Matrix Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Adjective_Matrix();
                    }
                    return instance;
                }
            }
        }

        public string getAdjectiveText(char reac_table, int adj_ID)
        {
            return adj_list[Program.getReactionID(reac_table)].ElementAt(adj_ID);
        }

        public string getAdjectiveText(int reac_table, int adj_ID)
        {
            return adj_list[reac_table].ElementAt(adj_ID);
        }

        public int getAdjectiveID(char reac_table, string adj_text)
        {
            return adj_list[Program.getReactionID(reac_table)].FindIndex(x => x == adj_text);
        }

        public int getAdjectiveID(int reac_table, string adj_text)
        {
            return adj_list[reac_table].FindIndex(x => x == adj_text);
        }

        public int getAdjectiveTableSize(char reac_table)
        {
            return adj_list[Program.getReactionID(reac_table)].Count;
        }

        public int getAdjectiveTableSize(int reac_table)
        {
            return adj_list[reac_table].Count;
        }
    }
}
