using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales
{
    class Spaces
    {
        //In order of which they appear on encounter card
        public const int TYPE_MOUNTAINS = 0;
        public const int TYPE_DESERT = 1;
        public const int TYPE_SEA = 2;
        public const int TYPE_FOREST = 3;
        public const int TYPE_CITY = 4;
        public const int TYPE_ISLAND = 5;
        public const int TYPE_POWER = 6;

        public const int CONTINENT_ARABIA = 0;
        public const int CONTINENT_EUROPA = 1;
        public const int CONTINENT_AFRICA = 2;
        public const int CONTINENT_INDIA = 3;
        public const int CONTINENT_ASIA = 4;

       
        private int id;
        private string name;
        private int val;
        private int type;
        private int continent;
        private List<Spaces> connections;

        public Spaces()
        {
            connections = new List<Spaces>();
        }

        //public Spaces(int id, string name, int val, int type, int continent)
        //{
        //    this.ID = id;
        //    this.Name = name;
        //    this.Value = val;
        //    this.Type = type;
        //    this.Continent = continent;
            
        //}
    
        public List<Spaces> Connections
        {
            get { return connections; }
            set { connections = value; }
        }

        public int Continent
        {
            get { return continent; }
            set { continent = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Value
        {
            get { return val; }
            set { val = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string TypeText()
        {
            switch (this.Type)
            {
                case TYPE_MOUNTAINS:
                    return "Mountains";
                case TYPE_DESERT:
                    return "Desert";
                case TYPE_SEA:
                    return "Sea";
                case TYPE_FOREST:
                    return "Forest";
                case TYPE_CITY:
                    return "City";
                case TYPE_ISLAND:
                    return "Island";
                case TYPE_POWER:
                    return "Place of Power";
                default:
                    return "ERROR";
            }
        }

        public string ContinentText()
        {
            switch (this.Continent)
            {
                case CONTINENT_ARABIA:
                    return "Arabia";
                case CONTINENT_EUROPA:
                    return "Europa";
                case CONTINENT_AFRICA:
                    return "Africa";
                case CONTINENT_INDIA:
                    return "India";
                case CONTINENT_ASIA:
                    return "Asia";
                default:
                    return "ERROR";
            }
        }

    }
}
