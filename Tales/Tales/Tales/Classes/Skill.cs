using System;

namespace Tales
{
    public class Skill
    {
        public const int NUMBER_OF_SKILL = 18;

        public const int SKILL_ACTING_DISGUISE = 0;
        public const int SKILL_APPEARANCE = 1;
        public const int SKILL_BARGAINING_EVALUATION = 2;
        public const int SKILL_BEGUILING = 3;
        public const int SKILL_COURTLY_GRACES = 4;
        public const int SKILL_ENDURING_HARDSHIP = 5;
        public const int SKILL_LUCK = 6;
        public const int SKILL_MAGIC = 7;
        public const int SKILL_PIETY = 8;
        public const int SKILL_QUICK_THINKING = 9;
        public const int SKILL_SCHOLARSHIP = 10;
        public const int SKILL_SEAMANSHIP = 11;
        public const int SKILL_SEDUCTION = 12;
        public const int SKILL_STEALTH_STEALING = 13;
        public const int SKILL_STORYTELLING = 14;
        public const int SKILL_WEAPON_USE = 15;
        public const int SKILL_WILDERNESS_LORE = 16;
        public const int SKILL_WISDOM = 17;

        private bool is_Master = false;
        private bool has_skill = true;
        private int skill_ID = 0;

        public int SkillID
        {
            get { return skill_ID; }
            set { skill_ID = value; }
        }

        public bool IsMaster
        {
            get { return is_Master; }
            set { is_Master = value; }
        }
        
        public bool HasSkill
        {
            get { return has_skill; }
            set { has_skill = value; }
        }

        public string Name()
        {
            return GetName(this.SkillID);
        }



        public static string GetName(int skillID)
        {
            switch (skillID)
            {
                case SKILL_ACTING_DISGUISE:
                    return "Acting & Disguise";
                case SKILL_APPEARANCE:
                    return "Appearance";
                case SKILL_BARGAINING_EVALUATION:
                    return "Bargaining & Evaluation";
                case SKILL_BEGUILING:
                    return "Beguiling";
                case SKILL_COURTLY_GRACES:
                    return "Courtly Graces";
                case SKILL_ENDURING_HARDSHIP:
                    return "Enduring Hardship";
                case SKILL_LUCK:
                    return "Luck";
                case SKILL_MAGIC:
                    return "Magic";
                case SKILL_PIETY:
                    return "Piety";
                case SKILL_QUICK_THINKING:
                    return "Quick Thinking";
                case SKILL_SCHOLARSHIP:
                    return "Scholarship";
                case SKILL_SEAMANSHIP:
                    return "Seamanship";
                case SKILL_SEDUCTION:
                    return "Seduction";
                case SKILL_STEALTH_STEALING:
                    return "Stealth & Stealing";
                case SKILL_STORYTELLING:
                    return "Storytelling";
                case SKILL_WEAPON_USE:
                    return "Weapon Use";
                case SKILL_WILDERNESS_LORE:
                    return "Wilderness Lore";
                case SKILL_WISDOM:
                    return "Wisdom";
                default:
                    return null;
            }
        }

        public static string GetLevelName(bool master)
        {
            if (master) return "Master";
            return "Talent";                
        }
    }
}
