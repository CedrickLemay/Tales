using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    class City_Card_Reward
    {
        public const int TYPE_ENCOUNTER         = 0;
        public const int TYPE_SKILL             = 1;
        public const int TYPE_TREASURE          = 2;
        public const int TYPE_DESTINY           = 3;
        public const int TYPE_STORY             = 4;
        public const int TYPE_WEALTH            = 5;
        public const int TYPE_LOSE_STATUS       = 6;
        public const int TYPE_GAIN_STATUS       = 7;
        public const int TYPE_UPGRADE_SKILL     = 8;
        public const int TYPE_SKILL_ENCOUNTER   = 9;
           
        private int type;
        private string encounter_name;  //  Encounter
        private string encounter_table; //  Encounter
        private int skill_status_ID;    //  Status/Skill
        private int amount;             //  Treasure/Destiny/Story/Wealth
        private bool skill_lvl;         //  Skill
        private Wealth wealth;          //  Wealth    

        public Wealth WealthID
        {
            get { return wealth; }
            set { wealth = value; }
        }

        public bool SkillLevel
        {
            get { return skill_lvl; }
            set { skill_lvl = value; }
        }
        
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        
        public int SkillStatusID
        {
            get { return skill_status_ID; }
            set { skill_status_ID = value; }
        }
        
        public string EncounterTable
        {
            get { return encounter_table; }
            set { encounter_table = value; }
        }

        public string EncounterName
        {
            get { return encounter_name; }
            set { encounter_name = value; }
        }
        
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
                
        public City_Card_Reward(){ }
      
        public string getText()
        {
            
            switch (type)
            {
                case TYPE_ENCOUNTER:
                    return "Encounter " + encounter_name + " (" + encounter_table + ")";
                case TYPE_SKILL:
                    string name;                  
                    if (skill_status_ID == -1)
                        name = "any skill you want";
                    else
                        name = Skill.GetName(skill_status_ID);
                    return "Gain " + name;
                case TYPE_TREASURE:
                    return "Receive " + amount + " Treasure";
                case TYPE_DESTINY:
                    return "Gain D" + amount;
                case TYPE_STORY:
                    return "Gain S" + amount;
                case TYPE_WEALTH:
                    return "Gain W+" + amount + " (Max: " + wealth.getWealthName() + ")";
                case TYPE_LOSE_STATUS:
                    return "Lose any Statuses you wish";
                case TYPE_GAIN_STATUS:
                    return "Gain " + Status.GetName(skill_status_ID);
                case TYPE_UPGRADE_SKILL:
                    return "Improve any Talent to Master skill";
                case TYPE_SKILL_ENCOUNTER:
                    return "Gain " + Skill.GetName(skill_status_ID) + " plus encouter " + encounter_name + " (" + encounter_table + ")";
                default:
                    return "ERROR";
            }
            
        }

        public void getResult(Player p)
        {
            switch (type)
            {
                case TYPE_ENCOUNTER:
                    //TRIGGER ENCOUNTER
                    break;
                case TYPE_SKILL:
                    p.PlayerSkills[skill_status_ID].HasSkill = true;
                    break;
                case TYPE_TREASURE:
                    //Trigger choice
                    //Add treasure to player's treasure
                    break;
                case TYPE_DESTINY:
                    p.CurrentDestiny +=  amount;
                    if (p.CurrentDestiny > 20) p.CurrentDestiny = 20;
                    break;
                case TYPE_STORY:
                    p.CurrentStory += amount;
                    if (p.CurrentStory > 20) p.CurrentStory = 20;
                    break;
                case TYPE_WEALTH:
                    p.PlayerWealth += amount;
                    if (p.PlayerWealth.WealthValue > wealth.WealthValue) p.PlayerWealth = wealth;
                    break;
                case TYPE_LOSE_STATUS:
                    //TRIGGER CHOICE
                    for (int i = 0; i < Status.NUMBER_OF_STATUS; i++)
                    {
                        if (p.PlayerStatus[i].HasStatus)
                            Console.WriteLine(Status.GetName(i));
                    } 

                    p.PlayerStatus[skill_status_ID].HasStatus = false;
                    break;
                case TYPE_GAIN_STATUS:
                    p.PlayerStatus[skill_status_ID].HasStatus = true;
                    break;
                case TYPE_UPGRADE_SKILL:
                    //TRIGGER CHOICE
                    p.PlayerSkills[skill_status_ID].HasSkill = true;
                    p.PlayerSkills[skill_status_ID].IsMaster = skill_lvl;
                    break;
                case TYPE_SKILL_ENCOUNTER:
                    p.PlayerSkills[skill_status_ID].HasSkill = true;
                    //TRIGGER ENCOUNTER                    
                    break;
            }            

        }
    }
}
