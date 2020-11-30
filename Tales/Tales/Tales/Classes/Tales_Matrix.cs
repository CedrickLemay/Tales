using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    public sealed class Tales_Matrix
    {
        //http://www.csharp-examples.net/list/
        private static List<int[,]> tales_list;

        private static Tales_Matrix instance = null;
        private static readonly object padlock = new object();

        private Tales_Matrix()
        {
            string[] line_content;
            string[] lines;
            int[,] tales = new int[1,1];    //must be declared at some point before being added

            tales_list = new List<int[,]>();

            for (char i = 'A'; i <= 'O'; i++)  //COMMENT THIS
            {

                lines = System.IO.File.ReadAllLines("Tales_Matrix/Tales_Matrix_" + i +".txt");

                line_content = lines[0].Split(';');

                tales = new int[lines.Length, line_content.Length];

                for (int row = 0; row < lines.Length; row++)
                {
                    line_content = lines[row].Split(';');

                    for (int col = 0; col < line_content.Length; col++)
                    {
                        tales[row,col] = Int32.Parse(line_content[col]);
                    }

                }

                tales_list.Add(tales);

            }            
        }


        public static Tales_Matrix Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Tales_Matrix();
                    }
                    return instance;
                }
            }
        }


        public int getTaleID(int reac_table, int adj_ID, int reac_ID)
        {
            return tales_list.ElementAt(reac_table)[adj_ID, reac_ID];
        }

    }
}
