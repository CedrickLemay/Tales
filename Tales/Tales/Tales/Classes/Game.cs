using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    /*
     *      CHANGE IT TO STATIC CLASS
     */


    class Game
    {
        //Morning->Noon->Night->Morning-> ... so we use a % 3
        public const int PERIOD_MORNING = 0;
        public const int PERIOD_NOON = 1;
        public const int PERIOD_NIGHT = 2;

        private Stack<Quest>            quest_stack;   //Shuffle it at the begining
        private Stack<Encounter_Card>   encounter_stack;
        private List<Encounter_Card>    discarded_encounter_stack;
        private List<Treasure>          treasure_list;
        private bool[]                  isTreasureAvailable;
        private List<Player>            player_list;
        private bool[]                  isPlayerPlaying; 
        private int                     currentPlayer;
        private int                     firstWinningPlayer;
        private List<Spaces>            spaces;        
        private int                     dayPeriod;

        public int DayPeriod
        {
            get { return dayPeriod; }
            set { dayPeriod = value; }
        }

        public void ChangeDayPeriod()
        {
            DayPeriod = (DayPeriod + 1) % 3;
        }

        public void ChangeCurrentPlayer()
        {
            do
            {
                currentPlayer = (currentPlayer + 1) % 6;
            } while (isPlayerPlaying[currentPlayer] == false);
            
        }

        public Game()
        {
            discarded_encounter_stack = new List<Encounter_Card>();
            set_Encounter_Stack();            

            quest_stack = new Stack<Quest>();
            set_Quest_Stack();

            setTreasure();

            set_Spaces();

            dayPeriod = PERIOD_MORNING;

            isPlayerPlaying = new bool[6]; 
            for (int i = 0; i < 6; i++) { isPlayerPlaying[i] = false; }  //must be a better way to do it ...

            askWhoIsPlaying();  //TEMP

        }

        private void askWhoIsPlaying()
        {
            char answer;
            string goalSTR;
            int goal;
            Player p;
            player_list = new List<Player>();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Console.Write("Is " + getCharactersName(i) + " playing? [Y/N]  ");
                p = new Player();

                do
                {
                    Console.Write("\b \b");
                    answer =  Console.ReadKey().KeyChar;

                } while (Convert.ToChar(answer.ToString().ToUpper()) != 'Y' && Convert.ToChar(answer.ToString().ToUpper()) != 'N');

                if (Convert.ToChar(answer.ToString().ToUpper()) == 'Y')
                {
                    isPlayerPlaying[i] = true;
                    
                    p.IsFemale = (i == 4 || i == 5);
                    p.Name = getCharactersName(i);
                    p.Position = spaces.Find(pos => pos.Name.Contains("Baghdad"));

                    //  Story/Destiny 

                    Console.Write("What is your 'Story' goal? (The rest will go as Destiny) [0-20]  ");

                    goal = 0;

                    do
                    {
                        while (goal > 0)
                        {
                            Console.Write("\b \b");
                            goal /= 10;
                        }
                        goalSTR = Console.ReadLine();

                        if (int.TryParse(goalSTR, out goal) == true)
                        {
                            goal = Convert.ToInt32(goalSTR);
                        }
                        else
                        {
                            goal = -1;
                        }
                                              

                    } while (goal < 0 || goal > 20);

                    p.TargetStory       = goal;
                    p.TargetDestiny     = 20 - goal;
                                        
                }

                player_list.Add(p);

            }

            Console.Clear();

            for (int i = 0; i < 6; i++)
            {
                if (isPlayerPlaying[i] == true)
                {
                    Console.WriteLine(getCharactersName(i) + " is playing.    Story goal: " + player_list.ElementAt(i).TargetStory + "   Destiny goal: " + player_list.ElementAt(i).TargetDestiny);
                }
            }

            Console.ReadKey();
            Console.Clear();

        }

        public void doTurn()
        {
            Player p = player_list.ElementAt(currentPlayer);

            //Exemple d'un tour

            //Move
            Spaces s = askMove(p);
            p.Position = s;

            //Draw encounter card
            Encounter_Card ec = pick_Encounter_Card();
            int encounterTableNumber = 0;

            //Get Encounter Table
            if (ec.Type == Encounter_Card.TYPE_TERRAIN)
            {
                encounterTableNumber = ec.EncounterTable(p.Position.Type);
            }
            else if (ec.Type == Encounter_Card.TYPE_CHARACTER)
            {
                encounterTableNumber = ec.EncounterTable(DayPeriod);
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

            if (ec.Type == Encounter_Card.TYPE_CITY)
            {
                Console.Write("Do you want to keep this City Card? [Y/N]  ");
                do
                {

                } while (true);

                if (true)
                {

                }
                else
                {
                    discard_Encounter_Card(ec);
                }
            }
            else
            {
                discard_Encounter_Card(ec);
            }

            Console.ReadKey();
            Console.Clear();

        }


        /*
         *  Mouvement related 
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

        private Spaces askMove(Player p)
        {
            SpaceMouvement[] sm = new SpaceMouvement[spaces.Count];
            for (int i = 0; i < sm.Length; i++)
            {
                sm[i].Visited = false;
                sm[i].Distance = int.MaxValue;
            }
            sm[p.Position.ID].Visited = true;
            sm[p.Position.ID].Distance = 0;
            getAllPossibleMove(p.Position, 0, 0, ref sm, p.PlayerWealth);


            List<Spaces> possibleMove = new List<Spaces>();
            for (int i = 0; i < sm.Length; i++)
            {
                if (sm.ElementAt(i).Visited == true)
                    Console.WriteLine(i + 1);
                // possibleMove.Add(g.getGameSpaces().ElementAt(i));

            }
            int reponse = Convert.ToInt32(Console.ReadLine());
            return spaces.Find(x => x.ID == reponse - 1);
            //en fait on devrait demander ici ou est-ce qu'il veut aller.

        }

        private void getAllPossibleMove(Spaces s, int landDist, int seaDist, ref SpaceMouvement[] sm, Wealth w)
        {
            int index = s.ID;

            sm[index].Visited = true;
            sm[index].Distance = landDist + seaDist;

            if (landDist + seaDist == Math.Max(w.LandMouvement(), w.SeaMouvement()))
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
                    if (w.SeaMouvement() == seaDist)
                        continue;
                    newSea++;
                }
                else
                {
                    if (w.LandMouvement() == landDist)
                        continue;
                    newLand++;
                }

                if (sm[connection.ID].Visited == false || (sm[connection.ID].Visited == true && sm[connection.ID].Distance > (newLand + newSea)))
                {
                    getAllPossibleMove(connection, newLand, newSea, ref sm, w);
                }

            }

        }

        private string getCharactersName(int index)
        {
            switch(index)
            {
                case 0:
                    return "Ali Baba";
                    
                case 1:
                    return "Aladdin";
                    
                case 2:
                    return "Sinbad";
                    
                case 3:
                    return "Ma'Aruf";
                    
                case 4:
                    return "Zumurrud";
                    
                case 5:
                    return "Scheherazade";

                default:
                    return "God";
            }
        }

        private void setTreasure()
        {
            //for (int i = 0; i < 1; i++)
            //{
            //    isTreasureAvailable[i] = true;
            //}
            
        }

        public List<Spaces> getGameSpaces() //TEMPORAIRE. A SUPPRIMER
        {
            return spaces;
        }


        public void set_Spaces()
        {
            /*
            *      From CSV file: id; continent; nom; valeur; type; connection (Divided by comma)
            */

            string[] line_content;                        
            int[] connections;

            string[] lines = System.IO.File.ReadAllLines("MapConnections.txt");
            
            spaces = new List<Spaces>(lines.Count());
            for (int i = 0; i < spaces.Capacity; i++)
            {
                spaces.Add(new Spaces());
            }
            
            for (int i = 0; i < lines.Length; i++)  //COMMENT THIS
            {
                Spaces s = spaces.ElementAt(i);
                
                line_content = lines[i].Split(';');


                s.ID          = Int32.Parse(line_content[0]);
                s.Continent   = Int32.Parse(line_content[1]);
                s.Name        = line_content[2];
                s.Value       = Int32.Parse(line_content[3]);
                s.Type        = Int32.Parse(line_content[4]);
                connections   = line_content[5].Split(',').Select(Int32.Parse).ToArray();

                foreach (int index in connections)
                {
                    s.Connections.Add(spaces.ElementAt(index));
                }
                
            }

        }

        public void set_Quest_Stack()
        {
            //Make a list then put it in the stack like when you shuffle the encounters
        }

       /*
        *
        *   Set the Encounter Deck content
        *   
        */
        public void set_Encounter_Stack()
        {
            encounter_stack = new Stack<Encounter_Card>();

            string[] line_content;
            string[] lines = System.IO.File.ReadAllLines("Encounter_Card.txt");
            Encounter_Card current_Card = new Terrain_Encounter("ERROR", new int[] { 0 });
            string card_name;
            int[] values;
            string card_type;

            for (int i = 0; i < lines.Length; i++)
            {
                line_content = lines[i].Split(';');

                card_name = line_content[1];

                card_type = line_content[0];

                if (card_type == "City")
                {

                    City_Card_Reward[] rewards;
                    rewards = new City_Card_Reward[6];

                    values = new int[1];
                    values[0] = Int32.Parse(line_content[2]);
                    
                    for (int j = 0; j < 6; j++)
                    {
                        
                        String[] reward_content = line_content[j + 3].Split(',');
                        rewards[j] = new City_Card_Reward();
                        String type = reward_content[0];  

                        switch (type)
                        {
                            case "E":
                                rewards[j].Type = City_Card_Reward.TYPE_ENCOUNTER;
                                rewards[j].EncounterName = reward_content[1];
                                //CHECK FOR TABLE IF IT'S NUMBER (I think its all the same table for the choice in the table)
                                rewards[j].EncounterTable = reward_content[2];
                                break;
                            case "S":
                                rewards[j].Type = City_Card_Reward.TYPE_SKILL;
                                rewards[j].SkillStatusID = Int32.Parse(reward_content[1]);
                                break;
                            case "T":
                                rewards[j].Type = City_Card_Reward.TYPE_TREASURE;
                                rewards[j].Amount = Int32.Parse(reward_content[1]);
                                break;
                            case "D":
                                rewards[j].Type = City_Card_Reward.TYPE_DESTINY;
                                rewards[j].Amount = Int32.Parse(reward_content[1]);
                                break;
                            case "H":
                                rewards[j].Type = City_Card_Reward.TYPE_STORY;
                                rewards[j].Amount = Int32.Parse(reward_content[1]);
                                break;
                            case "W":
                                rewards[j].Type = City_Card_Reward.TYPE_WEALTH;
                                rewards[j].Amount = Int32.Parse(reward_content[1]);
                                rewards[j].WealthID = new Wealth(Int32.Parse(reward_content[2]));
                                break;
                            case "LS":
                                rewards[j].Type = City_Card_Reward.TYPE_LOSE_STATUS;
                                break;
                            case "GS":
                                rewards[j].Type = City_Card_Reward.TYPE_GAIN_STATUS;
                                rewards[j].SkillStatusID = Int32.Parse(reward_content[1]);
                                break;
                            case "US":
                                rewards[j].Type = City_Card_Reward.TYPE_UPGRADE_SKILL;
                                //TRIGGER CHOICE
                                rewards[j].SkillLevel = true;
                                break;
                            case "SE":
                                rewards[j].Type = City_Card_Reward.TYPE_SKILL_ENCOUNTER;
                                rewards[j].SkillStatusID = Int32.Parse(reward_content[1]);
                                rewards[j].EncounterName = reward_content[2];
                                rewards[j].EncounterTable = reward_content[3];
                                break;
                        }

                        
                    }


                    current_Card = new City_Encounter(card_name, values, rewards);


                }
                else
                {
                    values = new int[line_content.Length - 2];
                    for (int j = 0; j < values.Length; j++)
                    {
                        values[j] = Int32.Parse(line_content[j + 2]);
                    }

                    if (card_type == "Character")
                        current_Card = new Character_Encounter(card_name, values);
                    else if (card_type == "Terrain")
                        current_Card = new Terrain_Encounter(card_name, values);
                }
                
                encounter_stack.Push(current_Card);

            }

            //Then we need to shuffle it
            while (encounter_stack.Count > 0)
            {
                discarded_encounter_stack.Add(encounter_stack.Pop());
            }
            shuffle_Encounter_Deck();
            
        }



        /*
         * 
         *      Shuffle the Encounter Deck
         * 
         */
        public void shuffle_Encounter_Deck()
        {
            int index;
            while(discarded_encounter_stack.Count > 0)
            {
                index = Misc.RandomNumber(0, discarded_encounter_stack.Count-1);
                encounter_stack.Push(discarded_encounter_stack.ElementAt(index));
                discarded_encounter_stack.RemoveAt(index);
            }
           // Console.WriteLine("\n!!!RESHUFFLING CARD!!!\n");
        }




        /*
         * 
         *      Pick a card from the Encounter Deck
         *      If empty, we shuffle it back
         *      
         * 
         */         
        public Encounter_Card pick_Encounter_Card()
        {
            if (encounter_stack.Count() == 0) shuffle_Encounter_Deck();

            return encounter_stack.Pop();
        }



        /*
         * 
         *      Put an Encounter Card back into  the discarded stack
         * 
         */
        public void discard_Encounter_Card(Encounter_Card card)
        {
            discarded_encounter_stack.Add(card);
        }




        public Quest pick_Quest_Card()
        {
            return quest_stack.Pop();
        }

    }
}
