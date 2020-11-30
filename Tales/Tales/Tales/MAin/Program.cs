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

            Game g = new Game();

            Player p = new Player();
            p.Position = g.getGameSpaces().Find(pos => pos.Name.Contains("Baghdad"));
            for (int k = 0; k < 3; k++) //3 tour
            {
                //Exemple d'un tour

                //Move
                Spaces s = askMove(p, g);
                p.Position = s;

                //Draw encounter card
                Encounter_Card ec = g.pick_Encounter_Card();
                int encounterTableNumber = 0;

                //Get Encounter Table
                if (ec.Type == Encounter_Card.TYPE_TERRAIN)
                {
                    encounterTableNumber = ec.EncounterTable(p.Position.Type);
                }
                else if (ec.Type == Encounter_Card.TYPE_CHARACTER)
                {
                    encounterTableNumber = ec.EncounterTable(g.DayPeriod);
                }
                else if (ec.Type == Encounter_Card.TYPE_CITY)
                {
                    encounterTableNumber = ec.EncounterTable(0);
                }

                //Get encounter

                //Must throw dice
                //Misc m = Misc.Instance; // wtf fix this
                int diceroll = Misc.RandomNumber(1, 6); // wtf fix this

                int result = diceroll + p.Position.Value;
                if (p.CurrentDestiny == 3 || p.CurrentDestiny == 4)
                    result += 1;
                else if (p.CurrentDestiny >= 5)
                    result += 2;

                if (result > 12)
                    result = 12;


                Encounter_Matrix em = Encounter_Matrix.Instance;
                Encounter e = em.getEncounter(encounterTableNumber, result);

                Adjective_Matrix am = Adjective_Matrix.Instance;

                string Adjective = am.getAdjectiveText(e.ReactionTable, e.Adjective);
                string Name = e.Name;
                if (Name == "") Name = ec.Name;


                Console.WriteLine(Adjective + " " + Name + "\n");

                //Show reaction options
                Reaction_Matrix rm = Reaction_Matrix.Instance;
                for (int i = 0; i < rm.getReactionTableSize(e.ReactionTable); i++)
                {
                    Console.WriteLine((i + 1) + " - " + rm.getReactionText(e.ReactionTable, i));
                }

                //add verification
                int reponse = Convert.ToInt32(Console.ReadLine());

                Tales_Matrix tm = Tales_Matrix.Instance;

                Console.WriteLine(tm.getTaleID(e.ReactionTable, e.Adjective, reponse - 1));

                //IL MANQUE MAINTENANT LE DÉ DU DESTIN. 
                //(Il y a aussi la verification si on a un skill au niveau magistral. mais on ne peut pas faire 
                // ca tant qu'on a pas les resultats et les skill necessaire pour different resultat des Tales.)

                Console.ReadKey();
                Console.Clear();
            }
            

            Console.ReadKey();

        }

        /**
         * 
         *  I DONT THINK THIS SHOULD BE HERE.... ALL THAT FOLLOW.
         *  wELL.... THE NEXT 2-3-4 FUNCTIONs
         */
        private struct SpaceMouvement
        {
            private bool visited;

            public bool Visited
            {
                get { return visited; }
                set { visited = value; }
            }
            private int dist;

            public int Distance
            {
                get { return dist; }
                set { dist = value; }
            }
            
        }

        private static Spaces askMove(Player p, Game g)
        {
            SpaceMouvement[] sm = new SpaceMouvement[g.getGameSpaces().Count];
            for (int i = 0; i < sm.Length; i++)
            {
                sm[i].Visited = false;
                sm[i].Distance = int.MaxValue;
            }
            sm[p.Position.ID].Visited = true;
            sm[p.Position.ID].Distance = 0;
            getAllPossibleMove(p.Position, 0,0,ref sm,p.PlayerWealth);


            List<Spaces> possibleMove = new List<Spaces>();
            for (int i = 0; i < sm.Length; i++)
            {
                if (sm.ElementAt(i).Visited == true)
                    Console.WriteLine(i + 1);
                   // possibleMove.Add(g.getGameSpaces().ElementAt(i));

            }
            int reponse = Convert.ToInt32(Console.ReadLine());
            return g.getGameSpaces().Find(x => x.ID == reponse - 1);
            //en fait on devrait demander ici ou est-ce qu'il veut aller.
            
        }

        private static void getAllPossibleMove(Spaces s, int landDist, int seaDist,ref SpaceMouvement[] sm, Wealth w)
        {
            int index = s.ID;

            sm[index].Visited = true;
            sm[index].Distance = landDist + seaDist;

            if (landDist + seaDist == Math.Max(w.LandMouvement(),w.SeaMouvement())) 
            {
                return;
            }

            int newSea; 
            int newLand;

            foreach (Spaces connection in s.Connections)
            {
                
                newSea = seaDist;
                newLand = landDist;

                if (s.Type == Spaces.TYPE_SEA || connection.Type == Spaces.TYPE_SEA || s.Type == Spaces.TYPE_ISLAND || connection.Type == Spaces.TYPE_ISLAND)
                {
                    if(w.SeaMouvement() == seaDist)
                        continue;
                    newSea++;
                }
                else
                {
                    if (w.LandMouvement() == landDist)
                        continue;
                    newLand++;
                }

                if(sm[connection.ID].Visited == false || (sm[connection.ID].Visited == true && sm[connection.ID].Distance > (newLand + newSea)))
                {
                    getAllPossibleMove(connection, newLand, newSea, ref sm, w);
                }
                
            }

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

