using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    class Program
    {
        static private List<char> reaction_id;

        static void Main(string[] args)
        {
            setReaction_Index(); //Move to game
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(reaction_id.ElementAt(i));
            }

            //Game g = new Game();
            //Encounter_Card ec;

            //g.set_Encounter_Stack();

            //ec = g.pick_Encounter_Card();
            //Console.WriteLine(ec.getName());
            //Console.WriteLine(ec.getType());

            //ec = g.pick_Encounter_Card();
            //Console.WriteLine(ec.getName());
            //Console.WriteLine(ec.getType());

            //ec = g.pick_Encounter_Card();
            //Console.WriteLine(ec.getName());
            //Console.WriteLine(ec.getType());

            //ec = g.pick_Encounter_Card();
            //Console.WriteLine(ec.getName());
            //Console.WriteLine(ec.getType());      
 

            /* Adjective and Reaction Matrix test */



            //Console.WriteLine(Adjective_Matrix.Instance.getAdjectiveID('A', "Disguised"));
            //Console.WriteLine(Adjective_Matrix.Instance.getAdjectiveID(0, "Disguised"));
            //Console.WriteLine(Adjective_Matrix.Instance.getAdjectiveText('A', 2));
            //Console.WriteLine(Adjective_Matrix.Instance.getAdjectiveText(0, 2));

            //Console.WriteLine(Reaction_Matrix.Instance.getReactionID('G', "Wait for help"));
            //Console.WriteLine(Reaction_Matrix.Instance.getReactionID(6, "Wait for help"));
            //Console.WriteLine(Reaction_Matrix.Instance.getReactionText('G',1));
            //Console.WriteLine(Reaction_Matrix.Instance.getReactionText(6,1));


            /* Encounter Matrix test */

            Encounter_Matrix em = Encounter_Matrix.Instance;
            Adjective_Matrix am = Adjective_Matrix.Instance;

            int rt = em.getEncounter(56, 5).getReactionTable();
            int adj = em.getEncounter(56, 5).getAdjective();

            Console.WriteLine(rt);  //Should be 5
            Console.WriteLine(getReactionLetter(rt));  //Should be F
            Console.WriteLine(adj);  //Should be 3
            Console.WriteLine(am.getAdjectiveText(getAdjectiveText(rt,adj)));  //Should be House

            Console.WriteLine(em.getEncounter(56, 5).getName());  //Should be Fire



            /*Card + Position test*/


            Encounter_Card ec = new Terrain_Encounter("Dendan", new int[] { 42, 44, -1, 7, 46, 45 }, 'N');
            Spaces s = new Spaces("", 4, Spaces.TYPE_MOUNTAINS);

            Console.WriteLine(ec.getEncounterTable(s)); //should be 42
            

            /*Same as before, plus  Encounter*/
            int dicerole = 3;   //Need Randomizer

            Encounter e = em.getEncounter(ec.getEncounterTable(s), s.getValue() + dicerole);   //eventually add depending of the player points

            Console.WriteLine(e.getReactionTable());// should be 5
            Console.WriteLine(getReactionLetter(e.getReactionTable()));// should be F
            Console.WriteLine(e.getName());// should be River
            Console.WriteLine(e.getAdjective());// should be 7
            Console.WriteLine(am.getAdjectiveText(e.getAdjective()));// should be Mysterious

            //42;F;7;Mysterious;River


            /*Same as before, plus Tales*/
            int reaction;   //Need ask





            Console.ReadKey();

        }

        static private void setReaction_Index()
        {

            reaction_id = new List<char>();
            for (char i = 'A'; i <= 'O' ; i++)
            {
                reaction_id.Add(i);
            }
        }

        //get value 
        //get id
        // need A-O , and Adjective
        static public char getReactionLetter(int value)
        {           
            return reaction_id.ElementAt(value);
        }

        static public int getReactionID(char value)
        {
            return reaction_id.FindIndex(x => x == value);
           
        }

    }
}

