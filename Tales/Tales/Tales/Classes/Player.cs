using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tales
{

    class Player
    {
        private string name;
        private bool is_female;
        private Skill[] player_skills;
        private Status[] player_status;
        private List<Encounter_Card> city_card;
        private List<Treasure> treasure_card;
        private Spaces position;
        private Spaces destination;
        private Spaces origin;
        private int current_destiny = 0;
        private int target_destiny;
        private int current_story = 0;
        private int target_story;
        private Wealth player_wealth;
        private Spaces[] objectives;

        /*****************
         * CONSTRUCTOR
         * ***************/
        public Player()
        {
            objectives = new Spaces[3];

            player_status = new Status[Status.NUMBER_OF_STATUS]; //set to false  by default

            player_skills = new Skill[Skill.NUMBER_OF_SKILL];
            for (int i = 0; i < player_skills.Length; i++)
            {
                player_skills[i] = new Skill();
                player_skills[i].SkillID = i;
            }

            this.Name = "JoueurTest";
            this.PlayerWealth = new Wealth();   //set to poor
            this.IsFemale = false;
            this.CityCards = new List<Encounter_Card>();
            this.TreasureCards = new List<Treasure>();
            //mettre la position a bahgdad (DONE)
            //destination non setter ici
            //origin non setter ici
            


        }

      
        /*********************
         * GETTERS AND SETTER
         **********************/

        public Spaces[] Objectives
        {
            get { return objectives; }
            set { objectives = value; }
        }


        public Wealth PlayerWealth
        {
            get { return player_wealth; }
            set { player_wealth = value; }
        }


        public int TargetStory
        {
            get { return target_story; }
            set { target_story = value; }
        }


        public int CurrentStory
        {
            get { return current_story; }
            set { current_story = value; }
        }


        public int TargetDestiny
        {
            get { return target_destiny; }
            set { target_destiny = value; }
        }


        public int CurrentDestiny
        {
            get { return current_destiny; }
            set { current_destiny = value; }
        }


        public Spaces Origin
        {
            get { return origin; }
            set { origin = value; }
        }


        public Spaces Destination
        {
            get { return destination; }
            set { destination = value; }
        }


        public Spaces Position
        {
            get { return position; }
            set { position = value; }
        }

        public List<Treasure> TreasureCards
        {
            get { return treasure_card; }
            set { treasure_card = value; }
        }


        public List<Encounter_Card> CityCards
        {
            get { return city_card; }
            set { city_card = value; }
        }


        public Status[] PlayerStatus
        {
            get { return player_status; }
            set { player_status = value; }
        }


        public Skill[] PlayerSkills
        {
            get { return player_skills; }
            set { player_skills = value; }
        }


        public bool IsFemale
        {
            get { return is_female; }
            set { is_female = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        


    }
}