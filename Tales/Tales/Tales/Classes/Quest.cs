using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://boardgamegeek.com/filepage/45422/book-tales-encounter-tables-retyped

    /*
     
     
            RENDRE SIMILAIRE A CITY REWARD
     
     
     */

namespace Tales
{

    abstract class Quest
    {
        protected string name;
        protected string description;

        public Quest(string n, string d)
        {
            name = n;
            description = d;
        }

        abstract public void setQuest(ref Player p);

        abstract public bool verifyWin(ref Player p);

        abstract public bool verifyLose(ref Player p);

        abstract public bool getWinningReward(ref Player p);

        abstract public bool getLosingReward(ref Player p);
    }

    class Quest_Dream_Riches : Quest
    {
        public Quest_Dream_Riches(string n, string d) : base(n, d)
        {

        }

        public override void setQuest(ref Player p)
        {

        }

        public override bool verifyWin(ref Player p)
        {
            return true;
        }

        public override bool verifyLose(ref Player p)
        {
            return false;
        }

        public override bool getWinningReward(ref Player p)
        {
            
            p.CurrentDestiny += 1;  //set limit in the SET      
            p.CurrentStory += 1;    //set limit in the SET

            p.PlayerWealth += 3;
           
            //Pick treasure

            return true;

        }

        public override bool getLosingReward(ref Player p)
        {
            return true;
           
        }
    }




    class Quest_Pull_Of_The_Sea: Quest
    {
        public Quest_Pull_Of_The_Sea(string n, string d)
            : base(n, d)
        {

        }

        public override void setQuest(ref Player p)
        {

        }

        public override bool verifyWin(ref Player p)
        {
            return true;
        }

        public override bool verifyLose(ref Player p)
        {
            return false;
        }

        public override bool getWinningReward(ref Player p)
        {
           // p.setDestinyPoint(p.getDestinyPoint() + 1);
           // p.setStoryPoint(p.getStoryPoint() + 3);

            //New Talent

            return true;

        }

        public override bool getLosingReward(ref Player p)
        {
            return true;
        }
    }




    class Quest_Contest_Of_Champions : Quest
    {
        public Quest_Contest_Of_Champions(string n, string d)
            : base(n, d)
        {

        }

        public override void setQuest(ref Player p)
        {

        }

        public override bool verifyWin(ref Player p)
        {
            return true;
        }

        public override bool verifyLose(ref Player p)
        {
            return false;
        }

        public override bool getWinningReward(ref Player p)
        {
            //p.setDestinyPoint(p.getDestinyPoint() + 1);
           // p.setStoryPoint(p.getStoryPoint() + 1);
            //wealth +2 rich
            //Respect
            //robe of honor

            //New Talent

            return true;
        }

        public override bool getLosingReward(ref Player p)
        {
            return true;
        }
    }



    class Quest_Slay_Creature : Quest
    {
        public Quest_Slay_Creature(string n, string d)
            : base(n, d)
        {

        }

        public override void setQuest(ref Player p)
        {

        }

        public override bool verifyWin(ref Player p)
        {
            return true;
        }

        public override bool verifyLose(ref Player p)
        {
            return false;
        }

        public override bool getWinningReward(ref Player p)
        {
            int dice_result = 5;

            if (dice_result >= 2 && dice_result <= 5)
            {
                //nothing
            }
            else if (dice_result >= 6 && dice_result <= 11)
            {
               // p.setStoryPoint(p.getStoryPoint() + 2);
                //wealth +2 rich
                //Usage d'arme/Promptitude (whichever it is)
            }
            else if (dice_result >= 12)
            {
               // p.setStoryPoint(p.getStoryPoint()  + 2);
                //wealth +3 princiere
                //Usage d'arme/Promptitude (whichever it is)
            }

            return true;

        }

        public override bool getLosingReward(ref Player p)
        {
            return true ;
        }
    }
}
